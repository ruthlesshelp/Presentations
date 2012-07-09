using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace RayTraceDemo
{
  public partial class MainForm : Form
  {
    private StringBuilder[,] myLogs;

    public MainForm()
    {
      InitializeComponent();
    }

    private void myRunButton_Click(object sender, EventArgs e)
    {
      FormBorderStyle = FormBorderStyle.FixedSingle;
      myRunButton.Enabled = false;
      myHintLabel.Text = "Step 2: Wait while the image is being rendered";

      var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
      var tracer = new RayTracer(bitmap) {AntiAliasPasses = myAntiAliasCheckBox.Checked ? 2 : 1};
      var camera = new Camera(new Vector(0, 0.3, -50), new Vector(0, 1, 0), new Vector(1, 0, 0), Math.PI / 6);

      tracer.Shapes.Add(new Sphere(new Vector(0, 0, 2), 1) { Name = "Sphere#1", Texture = new CheckeredTexture(new SolidTexture(ColorUtil.ToVector(Color.Black)), new SolidTexture(ColorUtil.ToVector(Color.White)), Math.PI / 8), Diffuse = 0.5, Ambient = 0.3 });
      tracer.Shapes.Add(new Sphere(new Vector(2, 2, 1.5), 0.5) { Name = "Sphere#2", Texture = new SolidTexture(ColorUtil.ToVector(Color.Green)), Diffuse = 0.8, Ambient = 0.2 });
      tracer.Shapes.Add(new Sphere(new Vector(2, 0.5, 0.5), 0.5) { Name = "Sphere#3", Texture = new SolidTexture(ColorUtil.ToVector(Color.Yellow)), Diffuse = 0.8, Ambient = 0.2 });
      tracer.Shapes.Add(new Sphere(new Vector(-2, 1, 1), 0.3) { Name = "Sphere#4", Texture = new SolidTexture(ColorUtil.ToVector(Color.Red)), Diffuse = 0.2, Ambient = 0.2, Reflect = 1 });
      tracer.Shapes.Add(new Sphere(new Vector(-5, 0.5, 2), 0.7) { Name = "Sphere#5", Texture = new SolidTexture(ColorUtil.ToVector(Color.DeepSkyBlue)), Diffuse = 0.2, Ambient = 0.2, Reflect = 1 });
      
      tracer.Shapes.Add(new Plane(new Vector(0, -1, 0), -10) {Texture = new SolidTexture(ColorUtil.ToVector(Color.Gray)), Diffuse = 0.8, Ambient = 0.3, Reflect = 0});
      tracer.Shapes.Add(new Plane(new Vector(0, -1, 0), 10) {Texture = new SolidTexture(ColorUtil.ToVector(Color.DarkGray)), Diffuse = 0.8, Ambient = 0.3, Reflect = 0});
      tracer.Shapes.Add(new Plane(new Vector(0, 0, -1), 200) {Texture = new SolidTexture(ColorUtil.ToVector(Color.Gray)), Diffuse = 0.4, Ambient = 0.3, Reflect = 0});
      tracer.Shapes.Add(new Plane(new Vector(-1, 0, 0), -20) {Texture = new SolidTexture(ColorUtil.ToVector(Color.Red)), Diffuse = 0.8, Ambient = 0.2, Reflect = 0});
      tracer.Shapes.Add(new Plane(new Vector(-1, 0, 0), 20) {Texture = new SolidTexture(ColorUtil.ToVector(Color.Blue)), Diffuse = 0.8, Ambient = 0.2, Reflect = 0});

      tracer.Lights.Add(new SpotLight(new Vector(5, 5, 3), ColorUtil.ToVector(Color.LightGoldenrodYellow), 0.5));
      tracer.Lights.Add(new SpotLight(new Vector(-1, -1, -1), ColorUtil.ToVector(Color.White), 0.1));
      tracer.Lights.Add(new SpotLight(new Vector(1, 0, -1), ColorUtil.ToVector(Color.White), 0.4));

      myLogs = null;

      var timer = new Timer();
      var stopwatch = new Stopwatch();
      ThreadPool.QueueUserWorkItem(delegate
                                     {
                                       stopwatch.Start();
                                       tracer.RayTrace(camera, myLogs);
                                       BeginInvoke((MethodInvoker)delegate
                                                     {
                                                       FormBorderStyle = FormBorderStyle.Sizable;
                                                       timer.Stop();
                                                       UpdatePicture(tracer, bitmap);
                                                       myRunButton.Enabled = true;
                                                       myHintLabel.Text = "Step 3: In the dotTrace pop-up window click the 'Get Snapshot' button";
                                                     });
                                     });

      timer.Interval = 500;
      timer.Tick += delegate
      {
        UpdatePicture(tracer, bitmap);
        myTimeLabel.Text = stopwatch.Elapsed.ToString();
      };
      timer.Start();
    }

    private void UpdatePicture(RayTracer tracer, Bitmap bitmap)
    {
      lock (tracer.LockObject)
        pictureBox1.Image = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), PixelFormat.DontCare);
    }

    private void myAntiAliasCheckBox_CheckedChanged(object sender, EventArgs e)
    {

    }
  }
}