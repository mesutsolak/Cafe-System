using CP.WebUI.Models;
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

    [AccessDeniedAuthorize(Roles = "Admin")]
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
                    ReportViewOperation("CampaignList", _rd.CampaignList.TableName, "CampaignList", 0);
                    break;
                case "SiparişListesi":
                    ReportViewOperation("CartList", _rd.CartList.TableName, "CartList", 1);
                    break;
                case "KategoriListesi":
                    ReportViewOperation("CategoryList", _rd.CategoryList.TableName, "CategoryList", 2);
                    break;
                case "YorumListesi":
                    ReportViewOperation("CommentList", _rd.CommentList.TableName, "CommentList", 3);
                    break;
                case "FirmaBilgisiListesi":
                    ReportViewOperation("CompanyInformationList", _rd.CompanyInformationList.TableName, "CompanyInformationList", 4);
                    break;
                case "İletişimListesi":
                    ReportViewOperation("ContactList", _rd.ContactList.TableName, "ContactList", 5);
                    break;
                case "AnasayfaListesi":
                    ReportViewOperation("HomePageList", _rd.HomePageList.TableName, "HomePageList", 7);
                    break;
                case "MüzikListesi":
                    ReportViewOperation("MusicListView", _rd.MusicListView.TableName, "MusicListView", 8);
                    break;
                case "ÜrünListesi":
                    ReportViewOperation("ProductList", _rd.ProductList.TableName, "ProductList", 9);
                    break;
                case "DeğerlendirmeListesi":
                    ReportViewOperation("RateList", _rd.RateList.TableName, "RateList", 10);
                    break;
                case "RolListesi":
                    ReportViewOperation("RoleList", _rd.RoleList.TableName, "RoleList", 11);
                    break;
                case "SliderListesi":
                    ReportViewOperation("SliderList", _rd.SliderList.TableName, "SliderList", 13);
                    break;
                case "MasaListesi":
                    ReportViewOperation("TableList", _rd.TableList.TableName, "TableList", 12);
                    break;
                case "KullanıcıListesi":
                    ReportViewOperation("UserList", _rd.UserList.TableName, "UserList", 14);
                    break;
                case "KullanıcıRolüListesi":
                    ReportViewOperation("UserRoleList", _rd.UserRoleList.TableName, "UserRoleList", 15);
                    break;
                default:
                    break;
            }

            return PartialView();
        }
        public void ReportViewOperation(string queryname, string tablename, string rdlc, int index)
        {
            ReportViewer reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                AsyncRendering = true,
                //SizeToReportContent = true,
                //Width = Unit.Percentage(300),
                //Height = Unit.Percentage(200),
                Width = Unit.Pixel(1035),
                Height = Unit.Pixel(700),
                ShowExportControls = true
            };

            var connectionString = ConfigurationManager.ConnectionStrings["CafeProjectModel"].ConnectionString;


            SqlConnection conx = new SqlConnection(connectionString);
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM " + queryname, conx);

            adp.Fill(_rd, tablename);

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Rdlc\" + rdlc + ".rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReportDataset", _rd.Tables[index]));

            ViewBag.ReportViewer = reportViewer;




        }
    }
}