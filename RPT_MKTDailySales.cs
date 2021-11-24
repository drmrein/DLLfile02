// Decompiled with JetBrains decompiler
// Type: MF.Report.Marketing.Web.RPT_MKTDailySales
// Assembly: MF.Report.Marketing.Web, Version=6.0.2021.1123, Culture=neutral, PublicKeyToken=null
// MVID: F1F0AA7E-E946-48DB-AD4B-72A40C87C934
// Assembly location: C:\Users\Darma\Downloads\Object Deployment\Object Deployment\PCR\WISE\SERVER WEB-APPS\inetpub\wwwroot\CONFINS\bin\MF.Report.Marketing.Web.dll

// test remark
using AdIns.Applicationbloks.Data;
using Confins.Web;
using Confins.Web.WebUserControl;
using Confins.Web.WebUserControl.Search;
using RefCommon.X.UserControl.Report;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MF.Report.Marketing.Web
{
  public class RPT_MKTDailySales : WebFormBase
  {
    protected UCReportSearchX ucReportSearch;
    protected HtmlForm form1;
    protected ScriptManager smAgrmnt;
    protected UpdatePanel upPath;
    protected Label lblPath;
    protected UpdatePanel upToolbar;
    protected HtmlGenericControl dReportCth;

    private ReportControlParams scParam
    {
      get => (ReportControlParams) ((Control) this).ViewState[nameof (scParam)];
      set => ((Control) this).ViewState[nameof (scParam)] = (object) value;
    }

    private IList SpGet_GenericComboBox()
    {
      IList list = (IList) new List<KeyValuePair<string, string>>();
      try
      {
        string str1 = "spGet_WOM_ListOffice";
        string str2 = ConfigurationManager.ConnectionStrings["RefCommonSQLConn"].ToString();
        SqlConnection connection = (SqlConnection) DBHelper.getConnection(str2);
        if (connection.State == ConnectionState.Closed)
          connection.Open();
        while (connection.State == ConnectionState.Connecting)
          Thread.Sleep(1000);
        DataSet dataSet1 = new DataSet();
        DataSet dataSet2 = DBHelper.ExecuteDataset(str2, CommandType.StoredProcedure, str1, 0);
        if (connection != null && connection.State == ConnectionState.Open)
        {
          connection.Close();
          connection.Dispose();
        }
        for (int index = 0; index < dataSet2.Tables[0].Rows.Count; ++index)
          list.Add((object) new KeyValuePair<string, string>(dataSet2.Tables[0].Rows[index]["Key"].ToString(), dataSet2.Tables[0].Rows[index]["Value"].ToString()));
      }
      catch (Exception ex)
      {
      }
      return list;
    }

    private IList SpGet_GenericComboPos()
    {
      IList list = (IList) new List<KeyValuePair<string, string>>();
      try
      {
        string str1 = "spGet_WOM_ListKapos";
        string str2 = ConfigurationManager.ConnectionStrings["RefCommonSQLConn"].ToString();
        SqlConnection connection = (SqlConnection) DBHelper.getConnection(str2);
        if (connection.State == ConnectionState.Closed)
          connection.Open();
        while (connection.State == ConnectionState.Connecting)
          Thread.Sleep(1000);
        DataSet dataSet1 = new DataSet();
        DataSet dataSet2 = DBHelper.ExecuteDataset(str2, CommandType.StoredProcedure, str1, 0);
        if (connection != null && connection.State == ConnectionState.Open)
        {
          connection.Close();
          connection.Dispose();
        }
        for (int index = 0; index < dataSet2.Tables[0].Rows.Count; ++index)
          list.Add((object) new KeyValuePair<string, string>(dataSet2.Tables[0].Rows[index]["Key"].ToString(), dataSet2.Tables[0].Rows[index]["Value"].ToString()));
      }
      catch (Exception ex)
      {
      }
      return list;
    }

    private IList SpGet_GenericComboBoxReg()
    {
      IList list = (IList) new List<KeyValuePair<string, string>>();
      try
      {
        string str1 = "spGet_WOM_Regional";
        string str2 = ConfigurationManager.ConnectionStrings["RefCommonSQLConn"].ToString();
        SqlConnection connection = (SqlConnection) DBHelper.getConnection(str2);
        if (connection.State == ConnectionState.Closed)
          connection.Open();
        while (connection.State == ConnectionState.Connecting)
          Thread.Sleep(1000);
        DataSet dataSet1 = new DataSet();
        DataSet dataSet2 = DBHelper.ExecuteDataset(str2, CommandType.StoredProcedure, str1, 0);
        if (connection != null && connection.State == ConnectionState.Open)
        {
          connection.Close();
          connection.Dispose();
        }
        for (int index = 0; index < dataSet2.Tables[0].Rows.Count; ++index)
          list.Add((object) new KeyValuePair<string, string>(dataSet2.Tables[0].Rows[index]["Key"].ToString(), dataSet2.Tables[0].Rows[index]["Value"].ToString()));
      }
      catch (Exception ex)
      {
      }
      return list;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      ReportControlParams reportControlParams = new ReportControlParams();
      string str1 = "MKTDailySales";
      IList genericComboBox = this.SpGet_GenericComboBox();
      IList genericComboBoxReg = this.SpGet_GenericComboBoxReg();
      IList genericComboPos = this.SpGet_GenericComboPos();
      reportControlParams.AddReportSearchInputParams(new FixedSearchPropSpec[5]
      {
        new FixedSearchPropSpec("ltl_Agrmnt_GoLiveDtFrom_Search", "FromPeriod", typeof (DateTime), true, (SearchPropSpec.SearchCondition) 0, false, (SearchPropSpec.ValOptType) 0, false),
        new FixedSearchPropSpec("ltl_Agrmnt_GoLiveDtTo_Search", "ToPeriod", typeof (DateTime), true, (SearchPropSpec.SearchCondition) 0, false, (SearchPropSpec.ValOptType) 0, false),
        new FixedSearchPropSpec("ltl_OfficeRegionMbrX_OfficeRegionXId_Search", "RegJual", genericComboBoxReg, "Key", "Value", typeof (string), true, (UCReference.AdditionalSelectionType) 3, (SearchPropSpec.SearchCondition) 0, (object) null, false, (SearchPropSpec.ValOptType) 1),
        new FixedSearchPropSpec("ltl_PostOffice_OfficeName_Search", "Kapos", genericComboPos, "Key", "Value", typeof (string), true, (UCReference.AdditionalSelectionType) 3, (SearchPropSpec.SearchCondition) 0, (object) null, false, (SearchPropSpec.ValOptType) 1),
        new FixedSearchPropSpec("ltl_RefOffice_OfficeName_Search", "CabJual", genericComboBox, "Key", "Value", typeof (string), true, (UCReference.AdditionalSelectionType) 3, (SearchPropSpec.SearchCondition) 0, (object) null, false, (SearchPropSpec.ValOptType) 1)
      });
      string str2 = "{0}";
      string str3 = "{0}";
      string str4 = "{0}";
      string str5 = "{0}";
      string str6 = "{0}";
      reportControlParams.AddReportTemplateParams(new ReportTemplateParam[5]
      {
        new ReportTemplateParam("prFromPeriod", str4, new string[1]
        {
          "FromPeriod"
        }),
        new ReportTemplateParam("prToPeriod", str5, new string[1]
        {
          "ToPeriod"
        }),
        new ReportTemplateParam("prRegJual", str2, new string[1]
        {
          "RegJual"
        }),
        new ReportTemplateParam("prCabJual", str3, new string[1]
        {
          "CabJual"
        }),
        new ReportTemplateParam("prKapos", str6, new string[1]
        {
          "Kapos"
        })
      });
      this.ucReportSearch.SetAttribute(reportControlParams, str1);
      new Confins.WebLib.UIDataHelper.UIDataHelper().WriteMultilangText((Control) this, ((WebPageBase) this).LanguageCode);
    }
  }
}
