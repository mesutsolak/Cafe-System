using CP.WebUI.Reports.Dataset;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [Route("RaportList")]
        public PartialViewResult ReportView(string name)
        {


            return PartialView();
        }
        public void ReportViewOperation()
        {
            ReportViewer reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                AsyncRendering = true,
                SizeToReportContent = true,
                //Width = Unit.Percentage(1500),
                //Height = Unit.Percentage(1500),
                ShowExportControls = true
            };
        

        }
    }
}