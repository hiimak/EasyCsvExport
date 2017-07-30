using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace EasyCsvExporter
{
    class CsvExport
    {

        private string filePath;
        private bool hasClmnHeader;
        private Thread export;

        public string FilePath { get => filePath; set => filePath = value; }
        public bool HasClmnHeader { get => hasClmnHeader; set => hasClmnHeader = value; }

        /// <summary>
        /// Saves a CSV File from a DataTable as a new Thread
        /// </summary>
        /// <param name="dt"></param>
        public void ExportCSVAsync(DataTable dt)
        {
           export = new Thread(() => ExportCsv(dt));
           export.Start();
        }

        /// <summary>
        /// Saves a CSV File from a DataTable
        /// </summary>
        /// <param name="dt"></param>
        public void ExportCsv(DataTable dt)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();

            save.Filter = "CSV File|*.csv";

            save.ShowDialog();

            FilePath = save.FileName;

            StreamWriter writer = File.AppendText(FilePath);

            if (HasClmnHeader)
            {
                foreach (DataColumn clmn in dt.Columns)
                {
                    writer.WriteLine(clmn.ColumnName + ";");
                }
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string cellvalue = dt.Rows[i][j].ToString();

                    if (cellvalue != null)
                    {
                        writer.Write(cellvalue + ";");
                    }
                    else
                    {
                        writer.Write(";");
                    }

                    writer.WriteLine();
                }
            }

            writer.Close();
        }

        /// <summary>
        /// Saves a CSV File from a string[][] as a new Thread
        /// </summary>
        /// <param name="dt"></param>
        public void ExportCSVAsync(string[][] dt)
        {
            export = new Thread(() => ExportCsv(dt));
            export.Start();
        }

        /// <summary>
        /// Saves a CSV File from a string[][]
        /// </summary>
        /// <param name="dt"></param>
        public void ExportCsv(string[][] dt)
        {

        }

        /// <summary>
        /// Saves a CSV File from a multidimensional int array
        /// </summary>
        /// <param name="dt"></param>
        public void ExportCsv(int[][] dt)
        {

        }

        /// <summary>
        /// Saves a CSV File from a string[][] as a new Thread
        /// </summary>
        /// <param name="dt"></param>
        public void ExportCSVAsync(int[][] dt)
        {
            export = new Thread(() => ExportCsv(dt));
            export.Start();
        }

        /// <summary>
        /// Saves a CSV File from a double[][]
        /// </summary>
        /// <param name="dt"></param>
        public void ExportCsv(double[][] dt)
        {

        }

        /// <summary>
        /// Saves a CSV File from a double[][] as a new Thread
        /// </summary>
        /// <param name="dt"></param>
        public void ExportCSVAsync(double[][] dt)
        {
            export = new Thread(() => ExportCsv(dt));
            export.Start();
        }

        /// <summary>
        /// Saves a CSV File from a generic List
        /// </summary>
        /// <param name="dt"></param>
        public void ExportCsv<T>(List<T> dt)
        {

        }

        /// <summary>
        /// Saves a CSV File from a generic List as a new Thread
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        public void ExportCSVAsync<T>(List<T> dt)
        {
            export = new Thread(() => ExportCsv(dt));
            export.Start();
        }

    }
}
