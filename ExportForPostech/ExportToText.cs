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

        private bool _isRun = false;
        #region DB
        private DataTable Load_Data(DataRow dr)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;
                if (dr["DB_NAME"].ToString() == "LMES") MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;

                string process_name = dr["PROC_NAME"].ToString();
                //ARGMODE
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

                MyOraDB.Parameter_Values[0] = dr["ARG_TYPE"].ToString();
                MyOraDB.Parameter_Values[1] = dr["ARG_LINE"].ToString();
                MyOraDB.Parameter_Values[2] = dr["ARG_SDATE"].ToString();
                MyOraDB.Parameter_Values[3] = dr["ARG_EDATE"].ToString();
                MyOraDB.Parameter_Values[4] = dr["ARG_VAL1"].ToString();
                MyOraDB.Parameter_Values[5] = dr["ARG_VAL2"].ToString();
                MyOraDB.Parameter_Values[6] = dr["ARG_VAL3"].ToString();
                MyOraDB.Parameter_Values[7] = dr["ARG_VAL4"].ToString();
                MyOraDB.Parameter_Values[8] = dr["ARG_VAL5"].ToString();
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

        private DataTable Load_Proc()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_SMT_POSTECH.GET_PROC";
                //ARGMODE
                MyOraDB.ReDim_Parameter(7);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
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

                MyOraDB.Parameter_Values[0] = "";
                MyOraDB.Parameter_Values[1] = "";
                MyOraDB.Parameter_Values[2] = "";
                MyOraDB.Parameter_Values[3] = "";
                MyOraDB.Parameter_Values[4] = "";
                MyOraDB.Parameter_Values[5] = "";
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

        private void ExportToText_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Run();
        }

        private void Run()
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate {
                    if (_isRun) return;
                    _isRun = true;
                    DataTable dt = Load_Proc();
                    if (dt == null || dt.Rows.Count == 0) return;
                    string Path = Application.StartupPath + @"\Export\";

                    foreach (DataRow row in dt.Rows)
                    {
                        WriteLog("Execute: " + row["PROC_NAME"].ToString() + "|SEQ: " + row["SEQ"].ToString());
                        if (row["PATH_FOLDER"].ToString() != "") Path = row["PATH_FOLDER"].ToString();
                        DatatableToText(row, Load_Data(row), Path, string.Format(row["FILE_NAME"].ToString(), row["DATE_CREATE"].ToString()));
                        
                    }

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                _isRun = false;
            }
        }

        private void DatatableToText(DataRow dr, DataTable dt, string PathFolder, string FileName)
        {
            try
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    Write_LogDB(dr, "E", "No Data");
                    return;
                }

                if (!Directory.Exists(PathFolder)) Directory.CreateDirectory(PathFolder);
                using (StreamWriter sw = File.CreateText(PathFolder + FileName ))
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

                    Write_LogDB(dr, "S", "Execute Success");
                    WriteLog("  Execute Success");
                }
            }
            catch (Exception ex)
            {
                Write_LogDB(dr, "E", ex.ToString());
                WriteLog("  Error: " + ex.ToString());
            }
            
        }

        private void WriteLog(string argText)
        {
            txtLog.Text += argText + "\r\n";
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Run();
        }

        //static async void WriteCharacters()
        //{
        //    using (StreamWriter writer = File.CreateText("newfile.txt"))
        //    {
        //        await writer.WriteLineAsync("First line of example");
        //        await writer.WriteLineAsync("and second line");
        //    }
        //}
    }
}
