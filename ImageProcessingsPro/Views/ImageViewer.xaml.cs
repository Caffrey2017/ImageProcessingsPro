using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageProcessingsPro.Views {
    /// <summary>
    /// ImageViewer.xaml 的交互逻辑
    /// </summary>
    public partial class ImageViewer : UserControl {
        public ImageViewer() {
            InitializeComponent();
        }

        /// <summary>
        /// 图像当前位置像素值-鼠标移动回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageView_MouseMove(object sender, MouseEventArgs e) {
            //获取当前位置
            Point currentMousePoint = e.GetPosition(ImageView);
            int x = (int)Math.Floor(currentMousePoint.X);
            int y = (int)Math.Floor(currentMousePoint.Y);
            //显示当前位置
            tblkMousePixelX.Text = x.ToString();
            tblkMousePixelY.Text = y.ToString();

            //获取当前位置的像素值
            //System.Drawing.Color pixelColor = App.GetMainWindow().GetImageProject().GetOpenedBitmap().GetPixel(x, y);
            //System.Windows.Media.Color pixelMediaColor = System.Windows.Media.Color.FromRgb(pixelColor.R, pixelColor.G, pixelColor.B);
            //显示当前位置的像素值
            //tblkPixelColor.Text = "R:" + pixelColor.R.ToString() + ", " + "G:" + pixelColor.G.ToString() + ", " + "B:" + pixelColor.B.ToString();
            //显示像素值对应的颜色
            //bdColorPreview.Background = new SolidColorBrush(pixelMediaColor);
        }

        /// <summary>
        /// 导航栏按钮1-放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZoomIn_Click(object sender, RoutedEventArgs e) {
            zbImageZoom.Zoom(0.2);
        }

        /// <summary>
        /// 导航栏按钮2-缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZoomOut_Click(object sender, RoutedEventArgs e) {
            zbImageZoom.Zoom(-0.2);
        }

        /// <summary>
        /// 导航栏按钮3-适应屏幕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFitScreen_Click(object sender, RoutedEventArgs e) {
            zbImageZoom.FitToBounds();
        }

        /// <summary>
        /// 导航栏按钮4-图像1:1显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOriginalSize_Click(object sender, RoutedEventArgs e) {
            zbImageZoom.GoHome();
        }

        /// <summary>
        /// 导航栏按钮5-允许鼠标拖动开关（按下）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHand_Checked(object sender, RoutedEventArgs e) {

        }

        /// <summary>
        /// 导航栏按钮5-允许鼠标拖动开关（抬起）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHand_Unchecked(object sender, RoutedEventArgs e) {

        }

        /// <summary>
        /// 导航栏按钮6-显示导航窗开关（按下）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNavigation_Checked(object sender, RoutedEventArgs e) {
            zbImageZoom.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 导航栏按钮6-显示导航窗开关（抬起）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNavigation_Unchecked(object sender, RoutedEventArgs e) {
            zbImageZoom.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// 导航栏按钮7-计算图像统计特性指标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, RoutedEventArgs e) {

        }

        /// <summary>
        /// 导航栏按钮8-保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e) {

            BitmapSource bsrc = (BitmapSource)ImageView.Source;
            Microsoft.Win32.SaveFileDialog save_Dialog = new Microsoft.Win32.SaveFileDialog();
            save_Dialog.DefaultExt = ".png";
            save_Dialog.Filter = "(*.jpg,*.png,*.jpeg,*.bmp,*.gif,*.tiff)|*.jpg;*.png;*.jpeg;*.bmp;*.gif;*tiff|All files(*.*)|*.*";

            if (save_Dialog.ShowDialog() == true) {
                PngBitmapEncoder pngE = new PngBitmapEncoder();
                pngE.Frames.Add(BitmapFrame.Create(bsrc));
                using (Stream stream = File.Create(save_Dialog.FileName)) {
                    //pngE.QualityLevel = 100;//可以调低一点
                    pngE.Save(stream);
                }
            }
        }
    }
}
