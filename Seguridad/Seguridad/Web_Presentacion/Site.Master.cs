using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Web_Presentacion
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Application["Privilegio"] == null)
                {
                    Response.Redirect("~/Formularios/Login.aspx");
                }
                else
                {
                    string[] dato = { Application["Privilegio"].ToString() };
                    BindMenuControl(dato);
                }
            }
        }

        //funciones creadas
        protected void BindMenuControl(string[] dato)
        {
            ManejadorPermisos Mpermi = new ManejadorPermisos();

            try
            {
                DataSet dsPrivilegios = new DataSet();
                dsPrivilegios = Mpermi.traerMenu(dato);

                DataTable dtPrivilegios = new DataTable();
                dtPrivilegios = dsPrivilegios.Tables[0];


                dtPrivilegios = dsPrivilegios.Tables[0];
                if (dtPrivilegios != null && dtPrivilegios.Rows.Count > 0)
                {
                    foreach (DataRow drDataRow in dtPrivilegios.Rows)
                    {
                        if (Convert.ToInt32(drDataRow[0]) == Convert.ToInt32(drDataRow[2]))
                        {
                            MenuItem miMenuItem = new MenuItem(Convert.ToString(drDataRow[1]), Convert.ToString(drDataRow[0]), String.Empty, Convert.ToString(drDataRow[3]));
                            this.Menu.Items.Add(miMenuItem);
                            AddChildItem(ref miMenuItem, dtPrivilegios);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }

        protected void AddChildItem(ref MenuItem miMenuItem, DataTable dtDataTable)
        {

            foreach (DataRow drDataRow in dtDataTable.Rows)
            {

                if (Convert.ToInt32(drDataRow[2]) == Convert.ToInt32(miMenuItem.Value) && Convert.ToInt32(drDataRow[0]) != Convert.ToInt32(drDataRow[2]))
                {

                    MenuItem miMenuItemChild = new MenuItem(Convert.ToString(drDataRow[1]), Convert.ToString(drDataRow[0]), String.Empty, Convert.ToString(drDataRow[3]));

                    miMenuItem.ChildItems.Add(miMenuItemChild);

                    AddChildItem(ref miMenuItemChild, dtDataTable);

                }

            }

        }

    }
}