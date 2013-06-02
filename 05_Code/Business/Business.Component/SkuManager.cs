using System.Collections;
using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Wms;
using Framework.Core.Collections;

namespace Business.Component
{
    /// <summary>
    /// 货物管理器
    /// </summary>
    public class SkuManager
    {

        public static Sku GetSku(int skuId)
        {
            var repository = new SkuRepository();
            return repository.Get(skuId);
        }

        public static Pack GetPack(int packId)
        {
            var repository = new PackRepository();
            return repository.Get(packId);
        }

        /// <summary>
        /// 货物是否是单品管理方式
        /// </summary>
        /// <param name="skuId">货物编号</param>
        /// <returns>是单品管理货物返回true，否则返回false</returns>
        public static bool IsPieceManagementSku(int skuId)
        {
            SkuManagement skuManagement = GetSkuManagementMode(skuId);
            if (skuManagement != null)
                return skuManagement.PieceManagement;

            return false;
        }

        /// <summary>
        /// 获取货物库内条码
        /// </summary>
        /// <param name="skuId">货物编号</param>
        /// <returns>成功返回库内条码，否则返回空字符串</returns>
        public static string GetSkuBarcode(int skuId)
        {
            var repository = new SkuRepository();
            Sku sku = repository.Get(skuId);
            if (sku != null)
                return sku.Barcode;

            return string.Empty;
        }

        /// <summary>
        /// 获取货物UPC码
        /// </summary>
        /// <param name="skuId">货物编号</param>
        /// <returns>成功返回UPC码，否则返回空字符串</returns>
        public static string GetSkuUPC(int skuId)
        {
            var repository = new SkuRepository();
            Sku sku = repository.Get(skuId);
            if (sku != null)
                return sku.Upc;

            return string.Empty;
        }

        /// <summary>
        /// 获取货物缺省包装对象
        /// </summary>
        /// <param name="skuId">货物编号</param>
        /// <returns>成功返回包装对象，否则返回null</returns>
        public static Pack GetDefaultPack(int skuId)
        {
            var repository = new PackRepository();

            var query = new Query();
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));

            IList<Pack> packs = repository.GetListByQuery(query);
            foreach (Pack pack in packs)
            {
                if (pack.DefaultPack)
                    return pack;
            }

            return null;
        }

        /// <summary>
        /// 获取货物管理方式（已考虑货物分类）
        /// </summary>
        /// <param name="skuId">货物编号</param>
        /// <returns>返回货物管理方式对象，优先考虑货物自定义管理方式，否则考虑货物分类管理方式</returns>
        public static SkuManagement GetSkuManagementMode(int skuId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));

            var skuManagementRepository = new SkuManagementRepository();
            SkuManagement skuManagement = skuManagementRepository.GetByQuery(query);

            if (skuManagement != null)
                return skuManagement;
            else
            {
                var skuRepository = new SkuRepository();
                Sku sku = skuRepository.Get(skuId);

                var query1 = new Query();
                query1.Criteria.Add(new Criterion("CategoryId", CriteriaOperator.Equal, sku.CategoryId));

                var categoryManagementRepository = new CategoryManagementRepository();
                CategoryManagement categoryManagement = categoryManagementRepository.GetByQuery(query1);

                return new SkuManagement
                           {
                               AbcType = categoryManagement.AbcType,
                               BarcodeManagement = categoryManagement.BarcodeManagement,
                               ContainerManagement = categoryManagement.ContainerManagement,
                               CreateTime = categoryManagement.CreateTime,
                               CreateUser = categoryManagement.CreateUser,
                               EditTime = categoryManagement.EditTime,
                               EditUser = categoryManagement.EditUser,
                               IsActive = categoryManagement.IsActive,
                               IsBigItem = categoryManagement.IsBigItem,
                               IsHeavyItem = categoryManagement.IsHeavyItem,
                               BatchManagement = categoryManagement.BatchManagement,
                               PieceManagement = categoryManagement.PieceManagement
                           };
            }
        }


        public static SkuManagement GetSkuManagement(int skuId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));

            var skuManagementRepository = new SkuManagementRepository();
            return skuManagementRepository.GetByQuery(query);
        }
        /// <summary>
        /// 获取货物管理批次属性列表（已考虑货物分类）
        /// </summary>
        /// <param name="skuId">货物编号</param>
        /// <returns>返回货物批次属性列表，优先考虑货物自定义管理批次属性，否则考虑货物分类管理批次属性</returns>
        private static ArrayList GetSkuProperties(int skuId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));

            var skuPropertyRepository = new SkuPropertyRepository();
            ArrayList skuProperties = CollectionHelper.ToArrayList(skuPropertyRepository.GetListByQuery(query));
            var comparer = new SkuPropertyComparer();
            if (skuProperties.Count > 0)
            {
                skuProperties.Sort(comparer);
                return skuProperties;
            }
            else
            {
                var skuRepository = new SkuRepository();
                Sku sku = skuRepository.Get(skuId);

                var query1 = new Query();
                query1.Criteria.Add(new Criterion("CategoryId", CriteriaOperator.Equal, sku.CategoryId));

                var categoryPropertyRepository = new CategoryPropertyRepository();
                IList<CategoryProperty> categoryProperties = categoryPropertyRepository.GetListByQuery(query1);

                skuProperties = new ArrayList();
                foreach (CategoryProperty item in categoryProperties)
                {
                    skuProperties.Add(new SkuProperty
                                          {
                                              Priority = item.Priority,
                                              PropertyId = item.PropertyId,
                                              SkuId = skuId
                                          });
                }

                skuProperties.Sort(comparer);
                return skuProperties;
            }
        }

        /// <summary>
        /// 获取货物批次属性列表
        /// </summary>
        /// <param name="skuId">货物编号</param>
        /// <returns>成功返回批次属性列表，否则返回空列表</returns>
        public static List<BatchProperty> GetBatchProperty(int skuId)
        {
            ArrayList skuProperties = GetSkuProperties(skuId);

            var repository = new BatchPropertyRepository();
            var resultList = new List<BatchProperty>();
            foreach (SkuProperty item in skuProperties)
            {
                int propertyId = item.PropertyId;
                BatchProperty batchProperty = repository.Get(propertyId);
                resultList.Add(batchProperty);
            }

            return resultList;
        }

        /// <summary>
        /// 获取货物对象
        /// </summary>
        /// <param name="barcode">库内条码或UPC码</param>
        /// <returns>成功返回货物对象，否则返回null</returns>
        public static Sku GetSkuByBarcode(string barcode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("Barcode", CriteriaOperator.Equal, barcode));

            SkuRepository repository = new SkuRepository();
            Sku sku = repository.GetByQuery(query);

            if (sku != null) return sku;

            query.Criteria.Clear();
            query.Criteria.Add(new Criterion("Upc", CriteriaOperator.Equal, barcode));
            return repository.GetByQuery(query);
        }

        /// <summary>
        /// 获取货物对象
        /// </summary>
        /// <param name="merchantId">商家编号</param>
        /// <param name="barcode">库内条码或UPC码</param>
        /// <returns>成功返回货物对象，否则返回null</returns>
        public static Sku GetSkuByBarcode(int merchantId, string barcode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("MerchantId", CriteriaOperator.Equal, merchantId));
            query.Criteria.Add(new Criterion("Barcode", CriteriaOperator.Equal, barcode));

            SkuRepository repository = new SkuRepository();
            Sku sku = repository.GetByQuery(query);

            if (sku != null) return sku;

            query.Criteria.Clear();
            query.Criteria.Add(new Criterion("MerchantId", CriteriaOperator.Equal, merchantId));
            query.Criteria.Add(new Criterion("Upc", CriteriaOperator.Equal, barcode));
            return repository.GetByQuery(query);
        }

        /// <summary>
        /// 获取货物对象
        /// </summary>
        /// <param name="merchantId">商家编号</param>
        /// <param name="skuNumber">货物代码</param>
        /// <returns>成功返回货物对象，否则返回null</returns>
        public static Sku GetSkuByNumber(int merchantId, string skuNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("MerchantId", CriteriaOperator.Equal, merchantId));
            query.Criteria.Add(new Criterion("SkuNumber", CriteriaOperator.Equal, skuNumber));

            SkuRepository repository = new SkuRepository();
            return repository.GetByQuery(query);
        }

        /// <summary>
        /// 获取货物对象
        /// </summary>
        /// <param name="skuNumber">货物代码</param>
        /// <returns>成功返回货物对象，否则返回null</returns>
        public static Sku GetSkuByNumber(string skuNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("SkuNumber", CriteriaOperator.Equal, skuNumber));

            SkuRepository repository = new SkuRepository();
            return repository.GetByQuery(query);
        }

        /// <summary>
        /// 获取货物包装对象
        /// </summary>
        /// <param name="skuId">货物编号</param>
        /// <param name="packName">包装名称</param>
        /// <returns>成功返回包装对象，否则返回null</returns>
        public static Pack GetPackByName(int skuId, string packName)
        {
            SkuRepository repository = new SkuRepository();
            IList<Pack> packs = repository.GetPacks(skuId);

            foreach (var pack in packs)
                if (pack.PackName == packName)
                    return pack;

            return null;
        }

        /// <summary>
        /// 获取货物图片数量
        /// </summary>
        /// <param name="skuId">货物编号</param>
        /// <returns>货物图片数量</returns>
        public static int GetImageCount(int skuId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            SkuImageRepository repository = new SkuImageRepository();
            IList<SkuImage> images = repository.GetListByQuery(query);
            return images.Count;
        }

        /// <summary>
        /// 创建货物图片对象
        /// </summary>
        /// <param name="skuImage">货物图片对象</param>
        /// <returns>成功返回图片对象，否则返回null</returns>
        public static SkuImage CreateImage(SkuImage skuImage)
        {
            int skuId = skuImage.SkuId;
            int index = GetImageCount(skuId) + 1;
            skuImage.ImageIndex = index;

            SkuImageRepository repository = new SkuImageRepository();
            int id = repository.Create(skuImage);
            skuImage.Id = id;

            return skuImage;
        }

        /// <summary>
        /// 获取货物图片对象
        /// </summary>
        /// <param name="skuId">货物编号</param>
        /// <param name="index">图片序号</param>
        /// <returns>成功返回图片对象，否则返回null</returns>
        public static SkuImage GetImage(int skuId, int index)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("ImageIndex", CriteriaOperator.Equal, index));

            SkuImageRepository repository = new SkuImageRepository();
            SkuImage image = repository.GetByQuery(query);

            return image;
        }

        #region nested type: SkuPropertyComparer

        private class SkuPropertyComparer : IComparer
        {
            #region IComparer Members

            public int Compare(object x, object y)
            {
                return ((SkuProperty)x).Priority - ((SkuProperty)y).Priority;
            }

            #endregion
        }
        #endregion
    }
}