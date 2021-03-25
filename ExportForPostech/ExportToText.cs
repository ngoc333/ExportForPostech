using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.IO;


namespace ExportForPostech
{
    public partial class ExportToText : Form
    {
        public ExportToText()
        {
            InitializeComponent();
        }

        private static readonly string _strUser = System.Net.Dns.GetHostName();
        private readonly string _strIP = System.Net.Dns.GetHostEntry(_strUser).AddressList.GetValue(1).ToString();

        readonly string _connectionString = "user id = HUBICVJ; password = HUBICVJ; data source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 211.54.128.21)(PORT = 1521)))(CONNECT_DATA = (SID = HUBICVJ)(SERVER = DEDICATED)));pooling = true";
        readonly string _connectionLMES = "user id = LMES; password = LMES; data source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 211.54.128.21)(PORT = 1521)))(CONNECT_DATA = (SID = LMES)(SERVER = DEDICATED)));pooling = true";

        private bool _isRun = false;
        DataTable _dtProc;

        #region DB
        private DataTable Load_Data(string ArgDB, string ArgProc, string ArgType, string ArgLine = "", string ArgSdate = "",string ArgEdate = "",
                                    string ArgVal1 = "", string ArgVal2 = "", string ArgVal3 = "", string ArgVal4 = "", string ArgVal5 = "")
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;
                if (ArgDB == "LMES") MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                MyOraDB.TimeOut = 200000;
                //MyOraDB.ShowError = true;
                string process_name = ArgProc;

                MyOraDB.ReDim_Parameter(10);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE";
                MyOraDB.Parameter_Name[2] = "ARG_SDATE";
                MyOraDB.Parameter_Name[3] = "ARG_EDATE";
                MyOraDB.Parameter_Name[4] = "ARG_VAL1";
                MyOraDB.Parameter_Name[5] = "ARG_VAL2";
                MyOraDB.Parameter_Name[6] = "ARG_VAL3";
                MyOraDB.Parameter_Name[7] = "ARG_VAL4";
                MyOraDB.Parameter_Name[8] = "ARG_VAL5";
                MyOraDB.Parameter_Name[9] = "OUT_CURSOR";
                
                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[6] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[7] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[8] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[9] = (char)OracleType.Cursor;               

                MyOraDB.Parameter_Values[0] = ArgType;
                MyOraDB.Parameter_Values[1] = ArgLine;
                MyOraDB.Parameter_Values[2] = ArgSdate;
                MyOraDB.Parameter_Values[3] = ArgEdate;
                MyOraDB.Parameter_Values[4] = ArgVal1;
                MyOraDB.Parameter_Values[5] = ArgVal2;
                MyOraDB.Parameter_Values[6] = ArgVal3;
                MyOraDB.Parameter_Values[7] = ArgVal4;
                MyOraDB.Parameter_Values[8] = ArgVal5;
                MyOraDB.Parameter_Values[9] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        [Obsolete]
        private DataTable Load_Data_Direct(string ArgDB, string ArgProc, string ArgType, string ArgLine = "", string ArgSdate = "", string ArgEdate = "",
                                    string ArgVal1 = "", string ArgVal2 = "", string ArgVal3 = "", string ArgVal4 = "", string ArgVal5 = "")
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionLMES))
                {
                    connection.Open();
                    using (OracleTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                        using (OracleCommand command = new OracleCommand(ArgProc, connection))
                        {
                            command.Transaction = transaction;
                            
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("ARG_TYPE", OracleType.VarChar).Value = ArgType;
                            command.Parameters.Add("ARG_LINE", OracleType.VarChar).Value = ArgLine;
                            command.Parameters.Add("ARG_SDATE", OracleType.VarChar).Value = ArgSdate;
                            command.Parameters.Add("ARG_EDATE", OracleType.VarChar).Value = ArgEdate;
                            command.Parameters.Add("ARG_VAL1", OracleType.VarChar).Value = ArgVal1;
                            command.Parameters.Add("ARG_VAL2", OracleType.VarChar).Value = ArgVal2;
                            command.Parameters.Add("ARG_VAL3", OracleType.VarChar).Value = ArgVal3;
                            command.Parameters.Add("ARG_VAL4", OracleType.VarChar).Value = ArgVal4;
                            command.Parameters.Add("ARG_VAL5", OracleType.VarChar).Value = ArgVal5;
                            command.Parameters.Add("OUT_CURSOR", OracleType.Cursor);

                            command.Parameters["ARG_TYPE"].Direction = ParameterDirection.Input;
                            command.Parameters["ARG_LINE"].Direction = ParameterDirection.Input;
                            command.Parameters["ARG_SDATE"].Direction = ParameterDirection.Input;
                            command.Parameters["ARG_EDATE"].Direction = ParameterDirection.Input;
                            command.Parameters["ARG_VAL1"].Direction = ParameterDirection.Input;
                            command.Parameters["ARG_VAL2"].Direction = ParameterDirection.Input;
                            command.Parameters["ARG_VAL3"].Direction = ParameterDirection.Input;
                            command.Parameters["ARG_VAL4"].Direction = ParameterDirection.Input;
                            command.Parameters["ARG_VAL5"].Direction = ParameterDirection.Input;
                            command.Parameters["OUT_CURSOR"].Direction = ParameterDirection.Output;

                            DataTable dt = new DataTable();
                            (new OracleDataAdapter(command)).Fill(dt);
                            if (dt == null) return null;
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            
        }

        [Obsolete]
        private DataTable Load_Data_HubicDB(string ArgDB, string ArgProc, string ArgType, string ArgLine = "", string ArgSdate = "", string ArgEdate = "",
                                    string ArgVal1 = "", string ArgVal2 = "", string ArgVal3 = "", string ArgVal4 = "", string ArgVal5 = "")
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(ArgProc, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("ARG_TYPE", OracleType.VarChar).Value = ArgType;
                        command.Parameters.Add("ARG_LINE", OracleType.VarChar).Value = ArgLine;
                        command.Parameters.Add("ARG_SDATE", OracleType.VarChar).Value = ArgSdate;
                        command.Parameters.Add("ARG_EDATE", OracleType.VarChar).Value = ArgEdate;
                        command.Parameters.Add("ARG_VAL1", OracleType.VarChar).Value = ArgVal1;
                        command.Parameters.Add("ARG_VAL2", OracleType.VarChar).Value = ArgVal2;
                        command.Parameters.Add("ARG_VAL3", OracleType.VarChar).Value = ArgVal3;
                        command.Parameters.Add("ARG_VAL4", OracleType.VarChar).Value = ArgVal4;
                        command.Parameters.Add("ARG_VAL5", OracleType.VarChar).Value = ArgVal5;
                        command.Parameters.Add("OUT_CURSOR", OracleType.Cursor);

                        command.Parameters["ARG_TYPE"].Direction = ParameterDirection.Input;
                        command.Parameters["ARG_LINE"].Direction = ParameterDirection.Input;
                        command.Parameters["ARG_SDATE"].Direction = ParameterDirection.Input;
                        command.Parameters["ARG_EDATE"].Direction = ParameterDirection.Input;
                        command.Parameters["ARG_VAL1"].Direction = ParameterDirection.Input;
                        command.Parameters["ARG_VAL2"].Direction = ParameterDirection.Input;
                        command.Parameters["ARG_VAL3"].Direction = ParameterDirection.Input;
                        command.Parameters["ARG_VAL4"].Direction = ParameterDirection.Input;
                        command.Parameters["ARG_VAL5"].Direction = ParameterDirection.Input;
                        command.Parameters["OUT_CURSOR"].Direction = ParameterDirection.Output;

                        DataTable dt = new DataTable();
                        (new OracleDataAdapter(command)).Fill(dt);
                        if (dt == null) return null;
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }

        }


        private DataTable Load_Proc(string ArgType = "", string ArgVal1 = "", string ArgVal2 = "", string ArgVal3 = "", string ArgVal4 = "", string ArgVal5 = "")
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_SMT_POSTECH.GET_PROC";
                //ARGMODE
                MyOraDB.ReDim_Parameter(7);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE_RUN";
                MyOraDB.Parameter_Name[1] = "ARG_VAL1";
                MyOraDB.Parameter_Name[2] = "ARG_VAL2";
                MyOraDB.Parameter_Name[3] = "ARG_VAL3";
                MyOraDB.Parameter_Name[4] = "ARG_VAL4";
                MyOraDB.Parameter_Name[5] = "ARG_VAL5";
                MyOraDB.Parameter_Name[6] = "OUT_CURSOR";   

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[6] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ArgType;
                MyOraDB.Parameter_Values[1] = ArgVal1;
                MyOraDB.Parameter_Values[2] = ArgVal2;
                MyOraDB.Parameter_Values[3] = ArgVal3;
                MyOraDB.Parameter_Values[4] = ArgVal4;
                MyOraDB.Parameter_Values[5] = ArgVal5;
                MyOraDB.Parameter_Values[6] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        private bool Write_LogDB(DataRow dr, string ArgStatus, string ArgLog)
        {
            try
            {
                System.Data.DataSet retDS;
                COM.OraDB MyOraDB = new COM.OraDB();

                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = "MES.PKG_SMT_POSTECH.SAVE_LOG";

                MyOraDB.Parameter_Name[0] = "ARG_DB_NAME";
                MyOraDB.Parameter_Name[1] = "ARG_PROC_NAME";
                MyOraDB.Parameter_Name[2] = "ARG_SEQ";
                MyOraDB.Parameter_Name[3] = "ARG_STATUS";
                MyOraDB.Parameter_Name[4] = "ARG_LOG_RUN";
                MyOraDB.Parameter_Name[5] = "UPD_USER";

                for (int i = 0; i < MyOraDB.Parameter_Name.Length; i++)
                    MyOraDB.Parameter_Type[i] = (char)OracleType.VarChar;


                MyOraDB.Parameter_Values[0] = dr["DB_NAME"].ToString();
                MyOraDB.Parameter_Values[1] = dr["PROC_NAME"].ToString();
                MyOraDB.Parameter_Values[2] = dr["SEQ"].ToString();
                MyOraDB.Parameter_Values[3] = ArgStatus;
                MyOraDB.Parameter_Values[4] = ArgLog;
                MyOraDB.Parameter_Values[5] = _strIP + "|" + _strUser;
                MyOraDB.Add_Modify_Parameter(true);

                retDS = MyOraDB.Exe_Modify_Procedure();

                if (retDS == null) return false;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;               
            }
        }
        #endregion 

        [Obsolete]
        private void ExportToText_Load(object sender, EventArgs e)
        {
            setCboProc();
            Run();
        }

        [Obsolete]
        private void Run()
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate {
                    timer1.Enabled = false;
                    //if (_isRun)
                    //{
                    //    WriteLog("Program is running");
                    //    _isRun = false;
                    //    return;
                    //}

                    _isRun = true;
                    DataTable dt = Load_Proc();
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        timer1.Enabled = true;
                        return;
                    }
                    string Path = Application.StartupPath + @"\Export\";                  
                    DataTable dtGet = null;

                    WriteLog("Start Run");
                    foreach (DataRow row in dt.Rows)
                    {
                        WriteLog("Execute: " + row["PROC_NAME"].ToString() + "|SEQ: " + row["SEQ"].ToString());
                        if (row["PATH_FOLDER"].ToString() != "" ) Path = row["PATH_FOLDER"].ToString();
                        if (row["DB_NAME"].ToString() == "HUBIC")
                        {
                            dtGet = Load_Data_HubicDB(row["DB_NAME"].ToString(), row["PROC_NAME"].ToString(), row["ARG_TYPE"].ToString());
                        }
                        else
                        {
                            dtGet = Load_Data(row["DB_NAME"].ToString(), row["PROC_NAME"].ToString(), row["ARG_TYPE"].ToString());
                        }
                        DatatableToText(row, dtGet, Path, string.Format(row["FILE_NAME"].ToString(), row["DATE_CREATE"].ToString()));
                        
                    }
                    WriteLog("Finish Run");
                    timer1.Enabled = true;
                    _isRun = false;
                });
            }
            catch (Exception ex)
            {
                timer1.Enabled = true;
                _isRun = false;
                WriteLog("Error: " + ex.ToString());               
            }
            
        }

        [Obsolete]
        private void Export_Excel()
        {
            try
            {
                _isRun = true;

                string strProc = cboProc.SelectedValue.ToString();
                DateTime runDay = dtpDate.Value;
                string Path = Application.StartupPath + @"\Export\";
                string strType = NullToBlank(cboType.SelectedValue);
                string strSqlArgType = strType == "" ? "IS NULL" : " ='" + strType + "'";
                DataTable dt;
                DataRow row;
                WriteLog("Start Run");
                while (runDay.Date <= dtpEDate.Value.Date)
                {
                    WriteLog("Execute: " + strProc + " -->" + runDay.ToString("yyyyMMdd"));
                    
                    row = _dtProc.Select("NAME = '" + strProc + "' AND ARG_TYPE " + strSqlArgType).FirstOrDefault();
                    if (row["PATH_FOLDER"].ToString() != "" && chkSever.Checked) Path = row["PATH_FOLDER"].ToString();
                    if (row["DB_NAME"].ToString() == "HUBIC")
                        dt = Load_Data_HubicDB(row["DB_NAME"].ToString(), strProc, strType, "", runDay.ToString("yyyyMMdd"));
                    else
                        dt = Load_Data(row["DB_NAME"].ToString(), strProc, strType, "", runDay.ToString("yyyyMMdd"));
                    if (dt != null)
                    {
                        WriteLog("Row: " + dt.Rows.Count.ToString());
                        Excel.ExcelExport obj = new Excel.ExcelExport();
                        obj.WriteDataTableToExcel(dt, "Sheet1", string.Format(row["FILE_NAME"].ToString().Replace(".txt",".xlsx"), runDay.ToString("yyyyMMdd")), "");
                    }
                    else
                        WriteLog("Run No Data");
                    runDay = runDay.AddDays(1);
                }
                WriteLog("Finish Run");

                
            }
            catch (Exception ex)
            {
                timer1.Enabled = true;
                _isRun = false;
                WriteLog("Error: " + ex.ToString());
            }

        }

        [Obsolete]
        private void ExecAll()
        {
            try
            {
                timer1.Enabled = false;
                //if (_isRun)
                //{
                //    WriteLog("Program is running");
                //    _isRun = false;
                //    return;
                //}
                _isRun = true;
                DataTable dt = Load_Proc("RUN");
                if (dt == null || dt.Rows.Count == 0)
                {
                    WriteLog("No Data");
                    timer1.Enabled = true;
                    return;
                }

                string Path = Application.StartupPath + @"\Export\";
                DateTime runDay = dtpDate.Value;
                DataTable dtGet = null;

                WriteLog("Start Run");

                this.BeginInvoke((MethodInvoker)delegate {

                     
                    while (runDay <= dtpEDate.Value)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            WriteLog("Execute: " + row["PROC_NAME"].ToString() + "|SEQ: " + row["SEQ"].ToString());
                            if (row["PATH_FOLDER"].ToString() != "" && chkSever.Checked) Path = row["PATH_FOLDER"].ToString();
                            if (row["DB_NAME"].ToString() == "HUBIC")
                            {
                                dtGet = Load_Data_HubicDB(row["DB_NAME"].ToString(), row["PROC_NAME"].ToString(), row["ARG_TYPE"].ToString(), "", runDay.ToString("yyyyMMdd"));
                            }
                            else
                            {
                                dtGet = Load_Data(row["DB_NAME"].ToString(), row["PROC_NAME"].ToString(), row["ARG_TYPE"].ToString(), "", runDay.ToString("yyyyMMdd"));
                            }
                            DatatableToText(row, dtGet, Path, string.Format(row["FILE_NAME"].ToString(), runDay.ToString("yyyyMMdd")));
                            if (dtGet != null) dtGet.Clear();

                            
                        }
                        runDay = runDay.AddDays(1);
                    }
                    WriteLog("Finish Run");
                });
            }
            catch (Exception ex)
            {
                WriteLog("Error: " + ex.ToString());
            }
            finally
            {
                //_isRun = false;
                timer1.Enabled = true;
            }
        }

        [Obsolete]
        private void Exec()
        {
            try
            {
                //timer1.Enabled = false;
                //if (_isRun)
                //{
                //    WriteLog("Program is running");
                //    _isRun = false;
                //    return;
                //}
                    
                _isRun = true;
             
                string strProc = cboProc.SelectedValue.ToString();
                DateTime runDay = dtpDate.Value;
                string Path = Application.StartupPath + @"\Export\";
                string strType = NullToBlank(cboType.SelectedValue);
                string strSqlArgType = strType == "" ? "IS NULL" : " ='" + strType + "'";
                DataTable dt;
                DataRow row;
                WriteLog("Start Run");
                while (runDay.Date <= dtpEDate.Value.Date)
                {
                    WriteLog("Execute: " + strProc + " -->" + runDay.ToString("yyyyMMdd"));
                                    
                    row = _dtProc.Select("NAME = '" + strProc + "' AND ARG_TYPE " + strSqlArgType).FirstOrDefault();
                    if (row["PATH_FOLDER"].ToString() != "" && chkSever.Checked) Path = row["PATH_FOLDER"].ToString();
                    if (row["DB_NAME"].ToString() == "HUBIC")
                        dt = Load_Data_HubicDB(row["DB_NAME"].ToString(), strProc, strType, "", runDay.ToString("yyyyMMdd"));
                    else
                        dt = Load_Data(row["DB_NAME"].ToString(), strProc, strType, "", runDay.ToString("yyyyMMdd"));
                    if (dt != null)
                    {
                        WriteLog("Row: "  + dt.Rows.Count.ToString());
                        DatatableToText(null, dt, Path, string.Format(row["FILE_NAME"].ToString(), runDay.ToString("yyyyMMdd")));
                    }
                    else
                        WriteLog("Run No Data");
                    runDay = runDay.AddDays(1);
                }
                WriteLog("Finish Run");
            }
            catch (Exception ex)
            {
                WriteLog("Error: " + ex.ToString());
            }
            finally
            {
                _isRun = false;
                timer1.Enabled = true;
            }


        }

        private void DatatableToText(DataRow dr, DataTable dt, string PathFolder, string FileName)
        {
            try
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    if (dr != null) Write_LogDB(dr, "E", "No Data");
                    return;
                }

                if (!Directory.Exists(PathFolder)) Directory.CreateDirectory(PathFolder);
                using (StreamWriter sw = File.CreateText(PathFolder + FileName))
                {
                    //Column Name
                    foreach (DataColumn col in dt.Columns)
                    {
                        sw.Write(col.ColumnName.ToString());
                        sw.Write("\t");
                    }
                    sw.WriteLine();

                    //Data
                    foreach (DataRow row in dt.Rows)
                    {
                        bool firstCol = true;
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (!firstCol) sw.Write("\t");
                            sw.Write(row[col].ToString());
                            firstCol = false;
                        }
                        sw.WriteLine();
                    }

                    if (dr != null) Write_LogDB(dr, "S", "Execute Success");
                    WriteLog("Execute Success" + DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]"));
                }
            }
            catch (Exception ex)
            {
                if (dr != null) Write_LogDB(dr, "E", ex.ToString());
                WriteLog("Error: " + ex.ToString());
            }
            
        }


        private void setCboProc()
        {
            try
            {
                _dtProc = Load_Proc("CBO_PROC");
                DataView view = new DataView(_dtProc);

                cboProc.DataSource = view.ToTable(true, "CODE", "NAME").Select("1=1").Distinct().CopyToDataTable();
                cboProc.DisplayMember = "NAME";
                cboProc.ValueMember = "CODE";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void setCboType()
        {
            DataView view = new DataView(_dtProc);
            cboType.DataSource = view.ToTable(true, "NAME", "ARG_TYPE").Select("NAME = '" + cboProc.SelectedValue.ToString() + "'").Distinct().CopyToDataTable();
            cboType.DisplayMember = "ARG_TYPE";
            cboType.ValueMember = "ARG_TYPE";
        }

        private void WriteLog(string argText)
        {
            txtLog.Text += DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]-->") + argText + "\r\n";
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
            txtLog.Refresh();
            //txtLog.BeginInvoke(new Action(() =>
            //{
            //    txtLog.Text += argText + "\r\n";
            //    txtLog.SelectionStart = txtLog.TextLength;
            //    txtLog.ScrollToCaret();
            //    txtLog.Refresh();
            //}));
        }

        private string NullToBlank (object obj)
        {
            if (obj == null) return "";
            return obj.ToString();
        }

        [Obsolete]
        private void timer1_Tick(object sender, EventArgs e)
        {
            Run();
        }

        private void cboProc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setCboType();
        }

        [Obsolete]
        private void cmdRun_Click(object sender, EventArgs e)
        {
            Exec();
        }

        [Obsolete]
        private void cmdRunAll_Click(object sender, EventArgs e)
        {
            ExecAll();
        }

        [Obsolete]
        private void cmd_ExportExcel_Click(object sender, EventArgs e)
        {
            Export_Excel();
        }
    }
}
