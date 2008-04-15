﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;


namespace littleRunner
{
    delegate void saveTmpDelegate(string filename);


    class TmpFileHandler : IDisposable
    {
        private string tmpFilename;
        private string originalFile;
        private Timer autoSaveTimer;
        private saveTmpDelegate saveHandler;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private string emptyMD5sum;

        public string TmpFilename
        {
            get { return tmpFilename; }
        }
        public string OrigFilename
        {
            get { return originalFile; }
        }

        public saveTmpDelegate SaveHandler
        {
            set { saveHandler = value; }
        }

        public TmpFileHandler(OpenFileDialog openFileDialog, SaveFileDialog saveFileDialog, saveTmpDelegate saveHandler, int minutes)
        {
            tmpFilename = Path.GetTempFileName();
            originalFile = "";
            this.openFileDialog = openFileDialog;
            this.saveFileDialog = saveFileDialog;

            // get empty md5 sum
            saveHandler(tmpFilename);
            emptyMD5sum = GetMD5(tmpFilename);


            autoSaveTimer = new Timer();
            autoSaveTimer.Tick += new EventHandler(autoSaveTimer_Tick);
            autoSaveTimer.Interval = minutes > 0 ? minutes * 60 * 1000 : 1;
            autoSaveTimer.Enabled = minutes != 0;
        }

        void autoSaveTimer_Tick(object sender, EventArgs e)
        {
            updateTMP();
        }



        private string GetMD5(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] md5hash = md5.ComputeHash(fs);
            fs.Close();

            return BitConverter.ToString(md5hash).Replace("-", "").ToLower();
        }

        public bool OriginalIsOld
        {
            get
            {
                string checkwith = originalFile == "" ? emptyMD5sum : GetMD5(originalFile);
                updateTMP();

                string tmp_md5 = GetMD5(tmpFilename);

                if (tmp_md5 == checkwith)
                    return false;
                else
                    return true;
            }
        }

        public void saveChanges()
        {
            if (OriginalIsOld)
            {
                // save?
                DialogResult result = MessageBox.Show("Do you want to save your changes?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                
                if (result == DialogResult.Yes)
                    SaveReal();
            }
        }

        public void updateTMP()
        {
            if (saveHandler != null)
                saveHandler(tmpFilename);
        }


        public void New()
        {
            //save old?
            saveChanges();

            originalFile = "";
        }


        public bool Open()
        {
            // maybe save old
            saveChanges();


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalFile = openFileDialog.FileName;
                File.Copy(originalFile, tmpFilename, true); // tmp -> actual!
                return true;
            }
            else
            {
                originalFile = "";
                return false;
            }

        }


        public void SaveReal()
        {
            if (originalFile == "")
                SaveAsReal();
            else
            {
                updateTMP();
                File.Copy(tmpFilename, originalFile, true);
            }
        }
        public bool SaveAsReal()
        {

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalFile = saveFileDialog.FileName;
                SaveReal();
                return true;
            }
            else
            {
                originalFile = "";
                return false;
            }

        }

        public void Dispose()
        {
            File.Delete(tmpFilename);
        }   
    }
}