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

using OpenTK;
using OpenTK.Graphics.OpenGL;

//namespace OpentkTutorials
//{
//    class Game: GameWindow
//    {
//        protected override void OnLoad(EventArgs e)
//        {
//            base.OnLoad(e);
//            Title = "Hello OpenTk";
//            GL.ClearColor(Color.CornflowerBlue);
//        }

//        protected override void OnRenderFrame(FrameEventArgs e)
//        {
//            base.OnRenderFrame(e);

//            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

//            GL.Begin(PrimitiveType.Triangles);
//            GL.Vertex3(-1.0f, -1.0f, 4.0f);
//            GL.Vertex3(1.0f, -1.0f, 4.0f);
//            GL.Vertex3(0.0f, 1.0f, 4.0f);
//            GL.Color3(1.0f, 0.0f, 0.0f);
//            GL.Vertex3(-1.0f, -1.0f, 4.0f);

//            GL.Color3(0.0f, 1.0f, 0.0f);
//            GL.Vertex3(1.0f, -1.0f, 4.0f);

//            GL.Color3(0.0f, 0.0f, 1.0f);
//            GL.Vertex3(0.0f, 1.0f, 4.0f);
//            GL.End();

//            SwapBuffers();
//        }

//        protected override void OnResize(EventArgs e)
//        {
//            base.OnResize(e);
//            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

//            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);

//            GL.MatrixMode(MatrixMode.Projection);

//            GL.LoadMatrix(ref projection);

//            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);

//            GL.MatrixMode(MatrixMode.Modelview);

//            GL.LoadMatrix(ref modelview);

            

//        }
//    }

    
//}

namespace pcltestWindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //HDevelopExport HD = new HDevelopExport();


        string image_path;
        public Form1()
        {
            InitializeComponent();
        }

        private void getRectCenter()
        {
            // Local iconic variables 
            
            HObject ho_image, ho_Region, ho_RegionTrans;
            HObject ho_RegionBorder;

            // Local control variables 

            HTuple hv_Width = null, hv_Height = null, hv_WindowHandle = hWindowControl1.HalconWindow;
            HTuple hv_Area = null, hv_Row = null, hv_Column = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_image);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_RegionTrans);
            HOperatorSet.GenEmptyObj(out ho_RegionBorder);
            //if (HDevWindowStack.IsOpen())
            //{
            //    HOperatorSet.CloseWindow(HDevWindowStack.Pop());
            //}
            //ho_image.Dispose();
            image_path = "G:/blazarlin/my_halcon_function/rect.png";
            HOperatorSet.ReadImage(out ho_image, image_path);
            HOperatorSet.GetImageSize(ho_image, out hv_Width, out hv_Height);
            HOperatorSet.SetWindowAttr("background_color", "black");
            //HOperatorSet.OpenWindow(0, 0, hv_Width / 1.2, hv_Height / 1.22, 0, "visible", "", out hv_WindowHandle);
            HDevWindowStack.Push(hv_WindowHandle);
            //阈值
            //ho_Region.Dispose();
            HOperatorSet.Threshold(ho_image, out ho_Region, 128, 255);
            // 外接矩形
            // ho_RegionTrans.Dispose();
            HOperatorSet.ShapeTrans(ho_Region, out ho_RegionTrans, "rectangle1");
            // 获取中心
            HOperatorSet.AreaCenter(ho_RegionTrans, out hv_Area, out hv_Row, out hv_Column);
            // 外边界
            // ho_RegionBorder.Dispose();
            HOperatorSet.Boundary(ho_RegionTrans, out ho_RegionBorder, "outer");
            HOperatorSet.DispObj(ho_image, HDevWindowStack.GetActive());
            // 显示边界
            // 设置绘制器的颜色
            HOperatorSet.SetColor(HDevWindowStack.GetActive(), "red");
            HOperatorSet.DispCross(hv_WindowHandle, hv_Row, hv_Column, 6, 0);
            HOperatorSet.SetColor(HDevWindowStack.GetActive(), "green");
            HOperatorSet.DispObj(ho_RegionBorder, HDevWindowStack.GetActive());
            HOperatorSet.SetTposition(hv_WindowHandle, hv_Row, hv_Column);
            HOperatorSet.WriteString(hv_WindowHandle, (hv_Row + new HTuple(",")) + hv_Column);

            //HOperatorSet.DispObj(ho_RegionBorder, hWindowControl1.HalconWindow);
            ho_image.Dispose();
            ho_Region.Dispose();
            ho_RegionTrans.Dispose();
            ho_RegionBorder.Dispose();
        }

        private void runHalconDemo()
        {
            // Local iconic variables 

            HObject ho_image;

            // Local control variables 

            HTuple hv_Width = null, hv_Height = null, hv_WindowHandle = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_image);

            HOperatorSet.ReadImage(out ho_image, "G:/blazarlin/calibrationdata/others/2020点胶机/旋转法/Images/mark/image mark0.bmp");
            HOperatorSet.GetImageSize(ho_image, out hv_Width, out hv_Height);
            HOperatorSet.SetWindowAttr("background_color", "black");
            HOperatorSet.DispImage(ho_image, hWindowControl1.HalconWindow);
            ho_image.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var reader = new PCDReader();
            //var cloud = new PointCloudOfXYZ();
            //reader.Read("rabbit.pcd", cloud);

            //runHalconDemo();
            getRectCenter();
            //textBox1.Text = "1111";
            //MessageBox.Show("33333");


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

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] names = fileDialog.FileNames;

                foreach (string file in names)
                {
                    image_path = file;
                    MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }
        }
    }
}
