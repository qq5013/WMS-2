using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Domain.Mobile.Wms;
using Business.Domain.Mobile.Application;
using Spring.Rest.Client;
using Newtonsoft.Json.Converters;
using Spring.Http.Converters.Json;
using Spring.Rest.Client;
using Spring.Http;
using Spring.Http.Converters;
using Spring.Http.Converters.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows;
using Spring.Rest.Client;
using Spring.Http.Converters.Json;
using Wms.Mobile.Common;

namespace Wms.Mobile
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CreateWarehouse();
            if (ValidateLogin())
            {
                Warehouse warehouse = cbWarehouse.SelectedItem as Warehouse;
                User user = cbUser.SelectedItem as User;

                try
                {
                    string encryptPassword = Framework.SmartDevice.Encryption.EncryptHelper.Encrypt(txtPassword.Text.Trim());
                    string uri = string.Format("User/Validate/{0}/{1}/{2}", warehouse.WarehouseCode, user.UserCode, encryptPassword);
                    User loginUser = GlobalState.MyRestService.GetForObject<User>(uri);
                    if (loginUser != null)
                    {
                        GlobalState.CurrentUser = user;
                        GlobalState.CurrentWarehouse = warehouse;
                        //Close();
                        this.Hide();
                        MainForm mf = new MainForm();
                        mf.Show();
                    }
                    else
                    {
                        MessageBox.Show("登录失败，请检查登录用户及口令。");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool ValidateLogin()
        {
            bool result = true;

            if (cbWarehouse.SelectedItem == null)
                result = false;
            if (cbUser.SelectedItem == null)
                result = false;

            if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("请输入登录口令。");
                txtPassword.Focus();
            }

            return result;
        }

        private void InitWarehouses()
        {
            try
            {
                string uri = string.Format("Warehouse/GetAll");
                var warehouses = GlobalState.MyRestService.GetForObject<List<Warehouse>>(uri);

                cbWarehouse.DataSource = null;
                cbWarehouse.DataSource = warehouses;
                cbWarehouse.DisplayMember = "WarehouseName";
                cbWarehouse.ValueMember = "WarehouseId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CreateWarehouse()
        {
            // create warehouse
            int number = new Random().Next(1000);
            var newApp = new Warehouse
            {
                WarehouseCode = "NJ",
                WarehouseName = "南京仓11" + number.ToString(),
                IsActive = true,
            };

            string uri = string.Format("Warehouse/Create");

            HttpHeaders headers = new HttpHeaders();
            headers.Accept = new MediaType[] { MediaType.APPLICATION_JSON, MediaType.APPLICATION_OCTET_STREAM };
            headers.ContentType = new MediaType("application", "json", System.Text.Encoding.UTF8);
            headers.Allow = new HttpMethod[] { HttpMethod.POST };

            string appStr = Newtonsoft.Json.JsonConvert.SerializeObject(newApp);
            HttpEntity entity = new HttpEntity(appStr, headers);
            string str = entity.Body.ToString();

            var postBin = Encoding.UTF8.GetBytes(entity.Body.ToString());
            headers.ContentLength = postBin.Length;
            try
            {
                Warehouse result = GlobalState.MyRestService.PostForObject<Warehouse>(uri, entity);
                //Warehouse newWH = (Warehouse)result;
                //int id = Int32.Parse(result);
                //newApp.ApplicationId = id;
                MessageBox.Show(result.WarehouseName);
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Test();
            //Close();
            System.Windows.Forms.Application.Exit();
        }

        private void Test()
        {
            //Business.Domain.Mobile.Application.Application application = new Business.Domain.Mobile.Application.Application()
            //{
            //    ApplicationCode = "Test",
            //    ApplicationName = "Test Application",
            //    IsActive = true,
            //    Remark = "Test Remark"
            //};

            //string uri = string.Format("Application");
            //HttpHeaders headers = new HttpHeaders();
            //headers.Accept = new MediaType[] { MediaType.APPLICATION_JSON, MediaType.APPLICATION_OCTET_STREAM };
            //headers.ContentType = new MediaType("application", "json", System.Text.Encoding.UTF8);
            //headers.Allow = new HttpMethod[] { HttpMethod.POST };

            //string appStr = Newtonsoft.Json.JsonConvert.SerializeObject(application);
            //HttpEntity entity = new HttpEntity(appStr, headers);
            //string str = entity.Body.ToString();

            //try
            //{
            //    Business.Domain.Mobile.Application.Application newApp = GlobalState.MyRestService.Execute<Business.Domain.Mobile.Application.Application>(uri, HttpMethod.PUT, entity);
            //    MessageBox.Show(newApp.ApplicationName);

                
            //}
            //catch (ServiceException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }


        private void cbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            object item = cbWarehouse.SelectedItem;
            if (item == null) return;

            Warehouse warehouse = item as Warehouse;
            if (warehouse != null)
                InitWarehouseUsers(warehouse.WarehouseCode);
        }

        private void InitWarehouseUsers(string warehouseCode)
        {
            try
            {
                string uri = string.Format("Warehouse/{0}/GetUsers", warehouseCode);
                var users = GlobalState.MyRestService.GetForObject<List<User>>(uri);

                cbUser.DataSource = null;
                cbUser.DataSource = users;
                cbUser.DisplayMember = "UserName";
                cbUser.ValueMember = "UserId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            InitWarehouses();

            this.txtPassword.Text = "123456";
        }
    }
}