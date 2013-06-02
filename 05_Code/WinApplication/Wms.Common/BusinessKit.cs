using System;
using System.Collections;
using System.Collections.Generic;

namespace Wms.Common
{
    public class BusinessKit
    {
        public static string GetDateTimeString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public static string GetServerTimeString()
        {
            return ServiceHelper.ApplicationService.GetServerDateTime().ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string FormatDateTimeString(DateTime dateTime)
        {
            if (dateTime.ToString("yyyy-MM-dd") != "1900-01-01")
                return dateTime.ToString("yyyy-MM-dd");
            
            return string.Empty;
        }

        //public static int GetDictionaryId(string condition)
        //{
        //    BllResult bllResult;
        //    ArrayList temp = GenericServiceHelper.GetListByCondition<DataDictionary>(out bllResult, condition);
        //    if (temp.Count > 0)
        //    {
        //        return ((DataDictionary)temp[0]).DictionaryId;
        //    }
        //    return 0;
        //}

        //public static void ConvertHashTableToArray(Hashtable ht, ref string[] keys, ref object[] paras)
        //{
        //    keys = new string[ht.Count];
        //    paras = new object[ht.Count];

        //    int counter = 0;
        //    foreach (string str in ht.Keys)
        //    {
        //        keys[counter] = str;

        //        // ����SQL����еĵ�����
        //        if (str != "SelectCondition")
        //            paras[counter] = ht[str];
        //        else
        //            paras[counter] = QueryHelper.FormatCondition((string)ht[str]);
                
        //        counter = counter + 1;
        //    }
        //}

        //#region Lock & Lock Log

        //public static int InsertLockLog(Lock @lock, string operation,int operatorId)
        //{
        //    var lockLog = new LockLog
        //                          {
        //                              BillId = @lock.BillId,
        //                              BillType = @lock.BillType,
        //                              StorageUnitId = @lock.StorageUnitId,
        //                              Description = @lock.Description,
        //                              GoodsCode = @lock.GoodsCode,
        //                              GoodsId = @lock.GoodsId,
        //                              GoodsName = @lock.GoodsName,
        //                              GoodsPacket = @lock.GoodsPacket,
        //                              InstrunctionId = @lock.InstrunctionId,
        //                              WarehouseId = @lock.WarehouseId,
        //                              JobId = @lock.JobId,
        //                              LocationId = @lock.LocationId,
        //                              LockTime = @lock.LockTime,
        //                              LockId = @lock.LockId,
        //                              LockMode = @lock.LockMode,
        //                              LockObject = @lock.LockObject,
        //                              LockReason = @lock.LockReason,
        //                              LockType = @lock.LockType,
        //                              Operation = operation,
        //                              Operator = operatorId,
        //                              PermitCountGoods = @lock.PermitCountGoods,
        //                              PermitIssueGoods = @lock.PermitIssueGoods,
        //                              PermitPickGoods = @lock.PermitPickGoods,
        //                              PermitPutaway = @lock.PermitPutaway,
        //                              PermitReceiveGoods = @lock.PermitReceiveGoods,
        //                              PermitTransferGoods = @lock.PermitTransferGoods,
        //                              GoodsQty = @lock.GoodsQty,
        //                              PieceQty = @lock.PieceQty
        //                          };
        //    BllResult bllResult;
        //    return ServiceHelper.FacadeService.Insert(out bllResult, typeof(LockLog).FullName, lockLog);
        //}

        //public static int InsertLockLog(LockLog lockLog, string operation)
        //{
        //    lockLog.Operation = operation;
        //    BllResult bllResult;
        //    return ServiceHelper.FacadeService.Insert(out bllResult, typeof(LockLog).FullName, lockLog);
        //}

        //#endregion

        //#region Basic Data
        ////�õ���˾��Ϣ
        //public static string GetCompanyName(int companyId)
        //{
        //    string result = "";
        //    if (companyId > 0)
        //    {
        //        BllResult bllResult;
        //        object obj = ServiceHelper.FacadeService.Get(out bllResult, typeof(Company).FullName, companyId);
        //        Company company = obj as Company;
        //        if (company != null)
        //            result = company.CompanyName;
        //    }
        //    return result;
        //}


        ////ͨ����˾�����ȡ��˾���
        //public static int GetCompanyId(string companyCode)
        //{
        //    int result = 0;
        //    if (companyCode != string.Empty)
        //    {
        //        string condition = string.Format("CompanyCode = '{0}'", companyCode);
        //        BllResult bllResult;
        //        ArrayList companyList = GenericServiceHelper.GetListByCondition<Company>(out bllResult, condition);

        //        if (companyList.Count > 0)
        //            result = ((Company)companyList[0]).CompanyId;
        //    }

        //    return result;
        //}

        ////��˾��ַ
        //private const string CompanyName = "Company Name:";
        ////��������
        //private const string Address = "Address:";
        ////��ϵ��
        //private const string Contactor = "Contact Person:";
        ////�绰
        //private const string Phone = "Tel:";
        ////����
        //private const string Fax = "Fax:";
        ////��������
        //private const string Email = "Email:";

        ////�õ���˾��Ϣ��ϵ��Ϣ
        //public static string GetContactInformation(int companyId)
        //{
        //    string result = "";
        //    if (companyId > 0)
        //    {
        //        BllResult bllResult;
        //        object obj = ServiceHelper.FacadeService.Get(out bllResult, typeof(Company).FullName, companyId);
        //        Company company = obj as Company;

        //        if (company != null)
        //            result = CompanyName + company.CompanyName + Environment.NewLine
        //                   + Address + company.Address + Environment.NewLine
        //                   + Contactor + company.Contactor + Environment.NewLine
        //                   + Phone + company.Phone + Environment.NewLine
        //                   + Fax + company.Fax + Environment.NewLine
        //                   + Email + company.Email;
        //    }
        //    return result;
        //}

        //// �õ�������Ϣ
        //public static string GetDepartmentName(int departmentId)
        //{
        //    string result = "";
        //    if (departmentId > 0)
        //    {
        //        BllResult bllResult;
        //        object obj = ServiceHelper.FacadeService.Get(out bllResult, typeof(Department).FullName, departmentId);
        //        Department department = obj as Department;
        //        if (department != null)
        //            result = department.DepartmentName;
        //    }
        //    return result;
        //}

        ////�õ�Ա����Ϣ
        //public static string GetEmployeeName(int employeeId)
        //{
        //    string result = "";
        //    if (employeeId > 0)
        //    {
        //        BllResult bllResult;
        //        object obj = ServiceHelper.FacadeService.Get(out bllResult, typeof(Employee).FullName, employeeId);
        //        Employee employee = obj as Employee;
        //        if (employee != null)
        //            result = employee.EmployeeName;
        //    }
        //    return result;
        //}

        ////�õ�Ա���Ա���Ϣ
        //public static ArrayList GetGenderList()
        //{
        //    ArrayList gender = new ArrayList();
        //    Gender man = new Gender {GenderId = 0, GenderName = "��"};
        //    Gender woman = new Gender {GenderId = 1, GenderName = "Ů"};

        //    gender.Add(man);
        //    gender.Add(woman);
        //    return gender;
        //}

        ////�õ��û���Ϣ
        //public static string GetUserName(int userId)
        //{
        //    string result = "";
        //    if (userId > 0)
        //    {
        //        BllResult bllResult;
        //        User user = GenericServiceHelper.Get<User>(out bllResult, userId);
        //        if (user != null)
        //            result = user.UserName;
        //    }
        //    return result;
        //}

        ////�õ������û���Ϣ
        //public static ArrayList GetAllUser()
        //{
        //    return ClientCacheHelper.LoadCache(CacheType.User);
        //}


        ////�õ������û�����Ϣ
        //public static ArrayList GetAllUserGroup()
        //{
        //    return ClientCacheHelper.LoadCache(CacheType.Usergroup);
        //}

        //public static ArrayList GetAllPacket()
        //{
        //    return ClientCacheHelper.LoadCache(CacheType.Packet);
        //}

        //public static Packet GetPiecePacket(int goodsId)
        //{
        //    BllResult bllResult;
        //    string condition = string.Format("GoodsId = {0} and ToPieceQty = 1", goodsId);

        //    ArrayList packetList = ServiceHelper.FacadeService.GetByCondition(out bllResult, typeof(Packet).FullName, condition);

        //    if (packetList.Count > 0)
        //        return (Packet)packetList[0];

        //    return null;
        //}

        //public static Packet GetDefaultPacket(int goodsId)
        //{
        //    BllResult bllResult;
        //    string condition = string.Format("GoodsId = {0} and IsDefault = 1", goodsId);
        //    ArrayList packetList = ServiceHelper.FacadeService.GetByCondition(out bllResult, typeof(Packet).FullName, condition);

        //    if (packetList.Count > 0)
        //        return (Packet)packetList[0];

        //    return null;
        //}

        ////�õ�����
        //public static string GetAreaName(int areaId)
        //{
        //    string result = "";
        //    if (areaId > 0)
        //    {
        //        BllResult bllResult;
        //        object obj = ServiceHelper.FacadeService.Get(out bllResult, typeof(Area).FullName, areaId);
        //        Area area = obj as Area;
        //        if (area != null)
        //            result = area.AreaName;
        //    }

        //    return result;
        //}

        //// �õ��ֿ���Ϣ
        //public static string GetWarehouseName(int warehousesId)
        //{
        //    string result = "";
        //    if (warehousesId > 0)
        //    {
        //        BllResult bllResult;
        //        object obj = ServiceHelper.FacadeService.Get(out bllResult, typeof(Warehouse).FullName, warehousesId);
        //        Warehouse warehouses = obj as Warehouse;
        //        if (warehouses != null)
        //            result = warehouses.WarehouseName;
        //    }
        //    return result;
        //}

        ////�õ���λ��Ϣ
        //public static string GetLocationName(int locationId)
        //{
        //    string result = "";
        //    if (locationId > 0)
        //    {
        //        BllResult bllResult;
        //        object obj = ServiceHelper.FacadeService.Get(out bllResult, typeof(Location).FullName, locationId);
        //        Location locations = obj as Location;
        //        if (locations != null)
        //            result = locations.LocationName;
        //    }
        //    return result;
        //}

        ////�õ�������Ϣ
        //public static string GetShelfName(int shelfId)
        //{
        //    string result = "";
        //    if (shelfId > 0)
        //    {
        //        BllResult bllResult;
        //        object obj = ServiceHelper.FacadeService.Get(out bllResult, typeof(Shelf).FullName, shelfId);
        //        Shelf shelf = obj as Shelf;
        //        if (shelf != null)
        //            result = shelf.ShelfName;
        //    }
        //    return result;
        //}

        ////�õ�������Ϣ
        //public static string GetGoodsName(int goodsId)
        //{
        //    string result = "";
        //    if (goodsId > 0)
        //    {
        //        BllResult bllResult;
        //        object obj = ServiceHelper.FacadeService.Get(out bllResult, typeof(Goods).FullName, goodsId);
        //        Goods goods = obj as Goods;
        //        if (goods != null)
        //            result = goods.GoodsName;
        //    }
        //    return result;
        //}


        ////�õ�������Ϣ
        //public static Goods GetGoods(int goodsId)
        //{
        //    if (goodsId > 0)
        //    {
        //        BllResult bllResult;
        //        object obj = ServiceHelper.FacadeService.Get(out bllResult, typeof(Goods).FullName, goodsId);
        //        Goods goods = obj as Goods;

        //        if (goods != null)
        //            return goods;
        //    }

        //    return null;
        //}

        //public static string GetPacketName(int packetId)
        //{
        //    BllResult bllResult;
        //    object obj = ServiceHelper.FacadeService.Get(out bllResult, typeof(Packet).FullName, packetId);
        //    Packet packet = obj as Packet;

        //    if (packet != null)
        //        return packet.PacketName;

        //    return string.Empty;
        //}

        //#endregion

        //#region Warehouse
        ////�õ��洢��������
        //public static string GetStorageUnitType(int storageUnitTypeId)
        //{
        //    string result = "";
        //    if (storageUnitTypeId > 0)
        //    {
        //        BllResult bllResult;
        //        object obj = ServiceHelper.FacadeService.Get(out bllResult, typeof(StorageUnitType).FullName, storageUnitTypeId);
        //        StorageUnitType containerType = obj as StorageUnitType;
        //        if (containerType != null)
        //            result = containerType.TypeName;
        //    }
        //    return result;
        //}

        //// �õ���������������Ϣ
        //public static ArrayList GetAllStorageUnitType()
        //{
        //    BllResult bllResult;
        //    return ServiceHelper.FacadeService.GetAll(out bllResult, typeof(StorageUnitType).FullName);
        //}

        ////�õ�������Ϣ
        //public static string GetStorageUnitName(int storageUnitId)
        //{
        //    string result = "";
        //    if (storageUnitId > 0)
        //    {
        //        BllResult bllResult;
        //        object obj = ServiceHelper.FacadeService.Get(out bllResult, typeof(StorageUnit).FullName, storageUnitId);
        //        StorageUnit storageUnit = obj as StorageUnit;
        //        if (storageUnit != null)
        //            result = storageUnit.StorageUnitName;
        //    }
        //    return result;
        //}

        //#endregion


        //#region ���ݴ���

        ///// <summary>
        ///// �������ƻ��Ż�ȡ���ƻ���ϸ��Ϣ
        ///// </summary>
        ///// <param name="inboundPlanId">���ƻ���</param>
        ///// <returns></returns>
        //public static ArrayList GetInboundPlanDetaiList(int inboundPlanId)
        //{
        //    BllResult bllResult;
        //    var arrayList = ServiceHelper.FacadeService.GetByCondition(out bllResult,
        //                                                      typeof(InboundPlanDetail).FullName,
        //                                                      string.Format("InboundPlanId = {0}",
        //                                                                    inboundPlanId));
        //    return arrayList;
        //}


        ////�õ��ɹ����ƻ���Ϣ
        //public static IList<PurchaseOrderDetail> GetPurchaseOrderDetailList(string condition)
        //{
        //    BllResult bllResult;
        //    ArrayList list = GenericServiceHelper.GetListByCondition<PurchaseOrderDetail>(out bllResult, condition);
        //    List<PurchaseOrderDetail> purchaseOrderDetailList = new List<PurchaseOrderDetail>();
        //    for (int i = 0, j = list.Count; i < j; i++)
        //    {
        //        purchaseOrderDetailList.Add((PurchaseOrderDetail)list[i]);
        //    }
        //    return purchaseOrderDetailList;
        //}

        //public static IList<SalesOrderDetail> GetSalesOrderDetailList(string condition)
        //{
        //    BllResult bllResult;
        //    ArrayList list = GenericServiceHelper.GetListByCondition<SalesOrderDetail>(out bllResult, condition);
        //    List<SalesOrderDetail> orderDetailList = new List<SalesOrderDetail>();
        //    for (int i = 0, j = list.Count; i < j; i++)
        //    {
        //        orderDetailList.Add((SalesOrderDetail)list[i]);
        //    }
        //    return orderDetailList;
        //}

        ////�õ������
        //public static IList<PickBillDetailView> GetPickBillDetailViewList(string condition)
        //{
        //    BllResult bllResult;
        //    ArrayList list = GenericServiceHelper.GetListByCondition<PickBillDetailView>(out bllResult, condition);
        //    List<PickBillDetailView> pickBillDetailViewList = new List<PickBillDetailView>();
        //    for (int i = 0, j = list.Count; i < j; i++)
        //    {
        //        pickBillDetailViewList.Add((PickBillDetailView)list[i]);
        //    }
        //    return pickBillDetailViewList;
        //}


        ////�õ��ջ��ƻ���Ϣ
        //public static IList<InboundPlanDetail> GetInboundPlanDetailList(string condition)
        //{
        //    BllResult bllResult;
        //    ArrayList list = GenericServiceHelper.GetListByCondition<InboundPlanDetail>(out bllResult, condition);
        //    List<InboundPlanDetail> inboundPlanDetailList = new List<InboundPlanDetail>();
        //    for (int i = 0, j = list.Count; i < j; i++)
        //    {
        //        inboundPlanDetailList.Add((InboundPlanDetail)list[i]);
        //    }
        //    return inboundPlanDetailList;
        //}

        ////�õ��ջ��ƻ���Ϣ
        //public static IList<OutboundPlanDetail> GetOutboundPlanDetailDetailList(string condition)
        //{
        //    BllResult bllResult;
        //    ArrayList list = GenericServiceHelper.GetListByCondition<OutboundPlanDetail>(out bllResult, condition);
        //    List<OutboundPlanDetail> planDetailDetailList = new List<OutboundPlanDetail>();
        //    for (int i = 0, j = list.Count; i < j; i++)
        //    {
        //        planDetailDetailList.Add((OutboundPlanDetail)list[i]);
        //    }
        //    return planDetailDetailList;
        //}



        ////�õ��ջ�����Ϣ
        //public static IList<InboundBillDetailView> GetInboundBillDetailList(string condition)
        //{
        //    BllResult bllResult;
        //    ArrayList list = GenericServiceHelper.GetListByCondition<InboundBillDetailView>(out bllResult, condition);

        //    List<InboundBillDetailView> views = new List<InboundBillDetailView>();
        //    for (int i = 0, j = list.Count; i < j; i++)
        //    {
        //        views.Add((InboundBillDetailView)list[i]);
        //    }
        //    return views;
        //}

        //////��������Ϣ
        //public static IList<PacketTrace> GetPacketTraceList(string condtion)
        //{
        //    BllResult bllResult;
        //    ArrayList list = GenericServiceHelper.GetListByCondition<PacketTrace>(out bllResult, condtion);

        //    List<PacketTrace> packetTraceList = new List<PacketTrace>();
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        packetTraceList.Add((PacketTrace)list[i]);
        //    }
        //    return packetTraceList;
        //}

        
        ////�õ��̵㵥��Ϣ
        //public static IList<CountBillDetail> GetCountBillDetailList(string condition)
        //{
        //    BllResult bllResult;
        //    ArrayList list = GenericServiceHelper.GetListByCondition<CountBillDetail>(out bllResult, condition);
        //    List<CountBillDetail> countBillDetailList = new List<CountBillDetail>();
        //    for (int i = 0, j = list.Count; i < j; i++)
        //    {
        //        countBillDetailList.Add((CountBillDetail)list[i]);
        //    }
        //    return countBillDetailList;
        //}

       
        ////�õ��ƻ���Ϣ
        //public static IList<TransferBillDetailView> GetTransferBillDetailList(string condition)
        //{
        //    BllResult bllResult;
        //    ArrayList list = GenericServiceHelper.GetListByCondition<TransferBillDetailView>(out bllResult, condition);
        //    List<TransferBillDetailView> views = new List<TransferBillDetailView>();
        //    for (int i = 0, j = list.Count; i < j; i++)
        //    {
        //        views.Add((TransferBillDetailView)list[i]);
        //    }
        //    return views;
        //}
        //#endregion

        //#region �õ������б�������

        //public static ArrayList GetDropDownList(string type)
        //{
        //    ArrayList list = DataListHelper.ConvertIListToArrayList(ClientCacheHelper.LoadCache(CacheType.DataDictionary));
        //    return DictionaryHelper.GetDictionaryList(list, type, 2);
        //}

        ////�ϼ���λ���
        //public static ArrayList GetMeasureList(string condition)
        //{
        //    BllResult bllResult;
        //    return ServiceHelper.FacadeService.GetByCondition(out bllResult, typeof(Measure).FullName, condition);
        //}


        ////��ȡ���ҡ�ʡ�ݡ�����
        //public static ArrayList GetRegionList(string condition)
        //{
        //    BllResult bllResult;
        //    return ServiceHelper.FacadeService.GetByCondition(out bllResult, typeof(Region).FullName, condition);
        //}


        ////��ȡ���л�ۿ�
        //public static ArrayList GetCityCountryList()
        //{
        //    BllResult bllResult;
        //    const string condition = "RegionLevel = 2 or RegionLevel = 3";
        //    return ServiceHelper.FacadeService.GetByCondition(out bllResult, typeof(Region).FullName, condition);
        //}

        //#endregion

        //#region �õ�����������Ϣ

        //public static string GetBarcode(int goodsId)
        //{
        //    BllResult bllResult;
        //    string str = "";
        //    var arrayList = ServiceHelper.FacadeService.GetByCondition(out bllResult,
        //                                                      typeof(Goods).FullName,
        //                                                      string.Format(" GoodsId = {0}",
        //                                                                    goodsId));
        //    if (arrayList.Count > 0)
        //    {
        //        var goods = (Goods)arrayList[0];
        //        if (goods != null)
        //        {
        //            str = goods.Barcode;
        //        }
        //    }
        //    return str;
        //}

      

        //public static List<UserGroupInRole> GetUserGroupListByRoleId(int roleId)
        //{
        //    List<UserGroupInRole> result = new List<UserGroupInRole>();
        //    if (roleId > 0)
        //    {
        //        string condition = string.Format("RoleId = {0}", roleId);
        //        BllResult bllResult;
        //        ArrayList arrayList = ServiceHelper.FacadeService.GetByCondition(out bllResult, typeof(UserGroupInRole).FullName, condition);
        //        if (arrayList.Count > 0)
        //        {
        //            for (int i = 0, j = arrayList.Count; i < j; i++)
        //            {
        //                result.Add((UserGroupInRole)arrayList[i]);
        //            }
        //        }
        //    }
        //    return result;
        //}
        //#endregion

        public static List<T> ArrayToList<T>(ArrayList arraylist)
        {
            List<T> result = new List<T>();

            if (arraylist == null) return result; 
            if (typeof(T).FullName != null)
            {
                if (arraylist.Count > 0)
                {
                    foreach (T info in arraylist)
                    {
                        result.Add(info);
                    }
                }
            }
            return result;
        }
    }

    public class Gender
    {
        private String _genderName;
        public String GenderName
        {
            get { return _genderName; }
            set { _genderName = value; }
        }

        private Int32 _genderId;
        public Int32 GenderId
        {
            get { return _genderId; }
            set { _genderId = value; }
        }
    }

}
