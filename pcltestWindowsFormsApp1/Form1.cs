using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PclSharp;
using PclSharp.IO;
using PclSharp.Utils;
using HalconDotNet;


namespace pcltestWindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //HDevelopExport HD = new HDevelopExport();

        public Form1()
        {
            InitializeComponent();
        }

        private void runHalconFunction()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var reader = new PCDReader();
            //var cloud = new PointCloudOfXYZ();
            //reader.Read("rabbit.pcd", cloud);

            // Local iconic variables 

            HObject ho_image;

            // Local control variables 

            HTuple hv_Width = null, hv_Height = null, hv_WindowHandle = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_image);

            
            HOperatorSet.ReadImage(out ho_image, "G:/blazarlin/calibrationdata/others/2020点胶机/旋转法/Images/mark/image mark0.bmp");
            HOperatorSet.GetImageSize(ho_image, out hv_Width, out hv_Height);
            HOperatorSet.SetWindowAttr("background_color", "black");
            //HOperatorSet.OpenWindow(0, 0, hv_Width / 1.2, hv_Height / 1.22, 0, "visible", "", hWindowControl1.HalconWindow);
            //HDevWindowStack.Push(hv_WindowHandle);
            //hWindowControl1.HalconWindow.SetPart(0, 0, hv_Width / 2, hv_Height / 2);
            HOperatorSet.DispObj(ho_image, hWindowControl1.HalconWindow);
            //HOperatorSet.DispImage(ho_image, hWindowControl1);
            ho_image.Dispose();

            //HD.action();
            textBox1.Text = "1111";
            MessageBox.Show("33333");


        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void hWindowControl1_HMouseMove(object sender, HMouseEventArgs e)
        {

        }

        private void hWindowControl2_HMouseMove(object sender, HMouseEventArgs e)
        {

        }

        private void hWindowControl1_HMouseMove_1(object sender, HMouseEventArgs e)
        {

        }
    }
}
