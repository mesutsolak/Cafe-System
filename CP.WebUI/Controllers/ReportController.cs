using CP.WebUI.Reports.Dataset;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CP.WebUI.Controllers
{
    public class ReportController : BaseController
    {
        ReportDataset _rd = new ReportDataset();
        // GET: Report
        [Route("Raporlar")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("RaporList")]
        [HttpPost]
        public PartialViewResult ReportView(string name)
        {
            switch (name)
            {
                case "KampanyaListesi":
                    ReportViewOperation("CampaignList", _rd.CampaignList.TableName, "CampaignList");
                    break;
                case "SiparişListesi":
                    ReportViewOperation("CartList", _rd.CartList.TableName, "CartList");
                    break;
                case "KategoriListesi":
                    ReportViewOperation("CategoryList", _rd.CategoryList.TableName, "CategoryList");
                    break;
                case "YorumListesi":
                    ReportViewOperation("CommentList", _rd.CommentList.TableName, "CommentList");
                    break;
                case "FirmaBilgisiListesi":
                    ReportViewOperation("CompanyInformationList", _rd.CompanyInformationList.TableName, "CompanyInformationList");
                    break;
                case "İletişimListesi":
                    ReportViewOperation("ContactList", _rd.ContactList.TableName, "ContactList");
                    break;
                case "AnasayfaListesi":
                    ReportViewOperation("HomePageList", _rd.HomePageList.TableName, "HomePageList");
                    break;
                case "MüzikListesi":
                    ReportViewOperation("MusicListView", _rd.MusicListView.TableName, "MusicListView");
                    break;
                case "ÜrünListesi":
                    ReportViewOperation("ProductList", _rd.ProductList.TableName, "ProductList");
                    break;
                case "DeğerlendirmeListesi":
                    ReportViewOperation("RateList", _rd.RateList.TableName, "RateList");
                    break;
                case "RolListesi":
                    ReportViewOperation("RoleList", _rd.RoleList.TableName, "RoleList");
                    break;
                case "SliderListesi":
                    ReportViewOperation("SliderList", _rd.SliderList.TableName, "SliderList");
                    break;
                case "MasaListesi":
                    ReportViewOperation("TableList", _rd.TableList.TableName, "TableList");
                    break;
                case "KullanıcıListesi":
                    ReportViewOperation("UserList", _rd.UserList.TableName, "UserList");
                    break;
                case "KullanıcıRolüListesi":
                    ReportViewOperation("UserRoleList", _rd.UserRoleList.TableName, "UserRoleList");
                    break;
                default:
                    break;
            }

            return PartialView();
        }
        public void ReportViewOperation(string queryname, string tablename, string rdlc)
        {
            ReportViewer reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                AsyncRendering = true,
                //SizeToReportContent = true,
                //Width = Unit.Percentage(300),
                //Height = Unit.Percentage(200),
                Width = Unit.Pixel(1045),
                Height = Unit.Pixel(700),
                ShowExportControls = true
            };

            var connectionString = ConfigurationManager.ConnectionStrings["CafeProjectModel"].ConnectionString;


            SqlConnection conx = new SqlConnection(connectionString); SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM " + queryname, conx);

            adp.Fill(_rd, tablename);

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Rdlc\" + rdlc + ".rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReportDataset", _rd.Tables[0]));

            ViewBag.ReportViewer = reportViewer;


        }
    }
}