//
// File generated by HDevelop for HALCON/.NET (C#) Version 17.12
//

using HalconDotNet;

public partial class HDevelopExport
{
#if !(NO_EXPORT_MAIN || NO_EXPORT_APP_MAIN)
  public HDevelopExport()
  {
    // Default settings used in HDevelop 
    HOperatorSet.SetSystem("width", 512);
    HOperatorSet.SetSystem("height", 512);
    if (HalconAPI.isWindows)
      HOperatorSet.SetSystem("use_window_thread","true");
    action();
  }
#endif

#if !NO_EXPORT_MAIN
  // Main procedure 
  private void action()
  {


    // Local iconic variables 

    HObject ho_image;

    // Local control variables 

    HTuple hv_Width = null, hv_Height = null, hv_WindowHandle = null;
    // Initialize local and output iconic variables 
    HOperatorSet.GenEmptyObj(out ho_image);
    if (HDevWindowStack.IsOpen())
    {
      HOperatorSet.CloseWindow(HDevWindowStack.Pop());
    }
    ho_image.Dispose();
    HOperatorSet.ReadImage(out ho_image, "G:/blazarlin/calibrationdata/others/2020点胶机/旋转法/Images/mark/image mark0.bmp");
    HOperatorSet.GetImageSize(ho_image, out hv_Width, out hv_Height);
    HOperatorSet.SetWindowAttr("background_color","black");
    HOperatorSet.OpenWindow(0,0,hv_Width/1.2,hv_Height/1.22,0,"visible","",out hv_WindowHandle);
    HDevWindowStack.Push(hv_WindowHandle);
    if (HDevWindowStack.IsOpen())
    {
      HOperatorSet.DispObj(ho_image, HDevWindowStack.GetActive());
    }
    ho_image.Dispose();

  }

#endif


}
#if !(NO_EXPORT_MAIN || NO_EXPORT_APP_MAIN)
public class HDevelopExportApp
{
  static void Main(string[] args)
  {
    new HDevelopExport();
  }
}
#endif

