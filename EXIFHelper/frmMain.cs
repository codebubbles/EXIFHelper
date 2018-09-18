using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EXIFHelper
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog source = new OpenFileDialog();
            source.Filter = "All Files (*.*)|*.*";
            source.FilterIndex = 1;
            source.Multiselect = true;

            if (source.ShowDialog() == DialogResult.OK)
            {
                lstFiles.Items.Clear();

                //string sFileName = source.FileName;
                string[] files = source.FileNames; //used when Multiselect = true
                foreach (var file in files)
                {
                    lstFiles.Items.Add(file);
                }
                btnWriteDate.Enabled = true;
                btnWriteGeoTag.Enabled = true;
            }

            lblFilesCount.Text = lstFiles.Items.Count.ToString() + " file(s) selected";
        }

        static void AddDatetime(Image original, byte[] datetime, string targetDirectory, string fileName)
        {
            const short ExifTypeAscii = 2;

            const int ExifTagDateTime = 0x9003;

            using (MemoryStream ms = new MemoryStream())
            {

                original.Save(ms, ImageFormat.Jpeg);
                ms.Seek(0, SeekOrigin.Begin);
                using (Image img = Image.FromStream(ms))
                {

                    AddProperty(img, ExifTagDateTime, ExifTypeAscii, datetime);

                    Directory.CreateDirectory(targetDirectory);
                    img.Save(targetDirectory + "\\" + fileName, ImageFormat.Jpeg);

                    //return img;
                }
            }

        }
        static void AddGeotag(Image original, double lat, double lng, string targetDirectory, string fileName)
        {
            // These constants come from the CIPA DC-008 standard for EXIF 2.3
            const short ExifTypeByte = 1;
            const short ExifTypeAscii = 2;
            const short ExifTypeRational = 5;

            const int ExifTagGPSVersionID = 0x0000;
            const int ExifTagGPSLatitudeRef = 0x0001;
            const int ExifTagGPSLatitude = 0x0002;
            const int ExifTagGPSLongitudeRef = 0x0003;
            const int ExifTagGPSLongitude = 0x0004;

            char latHemisphere = 'N';
            if (lat < 0)
            {
                latHemisphere = 'S';
                lat = -lat;
            }
            char lngHemisphere = 'E';
            if (lng < 0)
            {
                lngHemisphere = 'W';
                lng = -lng;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                original.Save(ms, ImageFormat.Jpeg);
                ms.Seek(0, SeekOrigin.Begin);
                using (Image img = Image.FromStream(ms))
                {
                    AddProperty(img, ExifTagGPSVersionID, ExifTypeByte, new byte[] { 2, 3, 0, 0 });
                    AddProperty(img, ExifTagGPSLatitudeRef, ExifTypeAscii, new byte[] { (byte)latHemisphere, 0 });
                    AddProperty(img, ExifTagGPSLatitude, ExifTypeRational, ConvertToRationalTriplet(lat));
                    AddProperty(img, ExifTagGPSLongitudeRef, ExifTypeAscii, new byte[] { (byte)lngHemisphere, 0 });
                    AddProperty(img, ExifTagGPSLongitude, ExifTypeRational, ConvertToRationalTriplet(lng));

                    Directory.CreateDirectory(targetDirectory);
                    img.Save(targetDirectory + "\\" + fileName, ImageFormat.Jpeg);

                    //return img;
                }

            }


        }

        static byte[] ConvertToRationalTriplet(double value)
        {
            int degrees = (int)Math.Floor(value);
            value = (value - degrees) * 60;
            int minutes = (int)Math.Floor(value);
            value = (value - minutes) * 60 * 100;
            int seconds = (int)Math.Round(value);
            byte[] bytes = new byte[3 * 2 * 4]; // Degrees, minutes, and seconds, each with a numerator and a denominator, each composed of 4 bytes
            int i = 0;
            Array.Copy(BitConverter.GetBytes(degrees), 0, bytes, i, 4); i += 4;
            Array.Copy(BitConverter.GetBytes(1), 0, bytes, i, 4); i += 4;
            Array.Copy(BitConverter.GetBytes(minutes), 0, bytes, i, 4); i += 4;
            Array.Copy(BitConverter.GetBytes(1), 0, bytes, i, 4); i += 4;
            Array.Copy(BitConverter.GetBytes(seconds), 0, bytes, i, 4); i += 4;
            Array.Copy(BitConverter.GetBytes(100), 0, bytes, i, 4);
            return bytes;
        }

        static void AddProperty(Image img, int id, short type, byte[] value)
        {
            PropertyItem pi = img.PropertyItems[0];
            pi.Id = id;
            pi.Type = type;
            pi.Len = value.Length;
            pi.Value = value;
            img.SetPropertyItem(pi);
        }

        private void btnCheckDate_Click(object sender, EventArgs e)
        {
            lstFilledFiles.Items.Clear();
            //webGeocode.Navigate(new Uri(@"file://c:\Images\geocode.html"));
            for (int i = 0; i < lstFiles.Items.Count; i++)
            {
                using (Image image = new Bitmap(lstFiles.Items[i].ToString()))
                {

                    PropertyItem[] propItems = image.PropertyItems;

                    int count = 0;
                    foreach (PropertyItem propItem in propItems)
                    {
                        //lstFiles.Items.Add(count + "   iD: 0x" + propItem.Id.ToString("x"));

                        if (propItem.Id == 0x9003) //id for date taken
                        {
                            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                            string propValue = encoding.GetString(propItems[count].Value);
                            if (string.IsNullOrEmpty(propValue) != true && propValue !="\0")
                            {                                
                                lstFilledFiles.Items.Add(Path.GetFileName(lstFiles.Items[i].ToString()) + "\t'" + propValue +"'");
                            }
                        }
                        count++;
                    }
                }
            }
        }

        private void btnWriteDate_Click(object sender, EventArgs e)
        {

            //try
            //{
            DateTime.ParseExact(txtDateTime.Text, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture,
                           DateTimeStyles.AssumeUniversal |
                           DateTimeStyles.AdjustToUniversal);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "Error");
            //    return;
            //}
            var sourceFiles = lstFiles.Items;
            foreach (var sourceFile in sourceFiles)
            {
                //try
                //{
                var fileName = Path.GetFileName(sourceFile.ToString());
                var sourceDirectory = Path.GetDirectoryName(sourceFile.ToString());
                var targetDirectory = sourceDirectory + "\\DateProcessed";


                using (Image image = new Bitmap(sourceFile.ToString()))
                {
                    AddDatetime(image, Encoding.UTF8.GetBytes(txtDateTime.Text + "\0"), targetDirectory, fileName);
                    //image.Save(targetDirectory + "\\" + fileName, ImageFormat.Jpeg);
                }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}
            }
            btnWriteDate.Enabled = false;
            MessageBox.Show("Date Processing Completed !!");
        }

        private void btnWriteGeoTag_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLatitude.Text) == true || string.IsNullOrWhiteSpace(txtLongitude.Text) == true)
            {
                MessageBox.Show("Please enter a value.");
                return;
            }
            var sourceFiles = lstFiles.Items;
            foreach (var sourceFile in sourceFiles)
            {
                //try
                //{
                using (Image image = new Bitmap(sourceFile.ToString()))
                {
                    var fileName = Path.GetFileName(sourceFile.ToString());
                    var sourceDirectory = Path.GetDirectoryName(sourceFile.ToString());
                    var targetDirectory = sourceDirectory + "\\GPSProcessed";
                    //Directory.CreateDirectory(targetDirectory);

                    AddGeotag(image, Convert.ToDouble(txtLatitude.Text), Convert.ToDouble(txtLongitude.Text), targetDirectory, fileName);
                    //image.Save(targetDirectory + "\\" + fileName, ImageFormat.Jpeg);
                }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}
            }
            btnWriteGeoTag.Enabled = false;
            MessageBox.Show("GPS Processing Completed !!");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //string applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            //string myFile = Path.Combine(applicationDirectory, "geocode.html");
            //webGeocode.Url = new Uri("file:///" + myFile);
            string curDir = Directory.GetCurrentDirectory();
            //webGeocode.Url =new Uri(String.Format("file:///{0}/geocode.html", curDir));
            //webGeocode.Navigate(new Uri(String.Format("file:///{0}/geocode.html", curDir)));
            //webGeocode.Navigate(new Uri("file://c:\\images\\geocode.html"));
        }

        private void btnRemoveFiles_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex != -1)
            {
                while (lstFiles.SelectedItems.Count != 0)
                {
                    lstFiles.Items.Remove(lstFiles.SelectedItems[0]);
                }
            }

            lblFilesCount.Text = lstFiles.Items.Count.ToString() + " file(s) selected";
        }

        private void webGeocode_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void btnCheckGeotag_Click(object sender, EventArgs e)
        {
            lstFilledFiles.Items.Clear();
            for (int i = 0; i < lstFiles.Items.Count; i++)
            {
                using (Image image = new Bitmap(lstFiles.Items[i].ToString()))
                {
                    var lati = GetLatitude(image).ToString();
                    var longi = GetLongitude(image).ToString();
                    lstFilledFiles.Items.Add(Path.GetFileName(lstFiles.Items[i].ToString()) + "\t" + lati + " " + longi);
                    //PropertyItem[] propItems = image.PropertyItems;

                    //int count = 0;
                    //foreach (PropertyItem propItem in propItems)
                    //{
                    //    //lstFiles.Items.Add(count + "   iD: 0x" + propItem.Id.ToString("x"));

                    //    //if (propItem.Id == 0x0) //id for date taken
                    //    //{
                    //    //    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                    //    //    string propValue = encoding.GetString(propItems[count].Value);
                    //    //    if (string.IsNullOrWhiteSpace(propValue) != true)
                    //    //    {
                    //    //        lstFilledFiles.Items.Add(lstFiles.Items[i].ToString() + "\t" + propValue);
                    //    //    }
                    //    //}
                    //    count++;
                    //}
                }
            }
        }

        public static double? GetLatitude(Image targetImg)
        {
            try
            {
                //Property Item 0x0001 - PropertyTagGpsLatitudeRef
                PropertyItem propItemRef = targetImg.GetPropertyItem(1);
                //Property Item 0x0002 - PropertyTagGpsLatitude
                PropertyItem propItemLat = targetImg.GetPropertyItem(2);
                return ExifGpsToDouble(propItemRef, propItemLat);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
        public static double? GetLongitude(Image targetImg)
        {
            try
            {
                ///Property Item 0x0003 - PropertyTagGpsLongitudeRef
                PropertyItem propItemRef = targetImg.GetPropertyItem(3);
                //Property Item 0x0004 - PropertyTagGpsLongitude
                PropertyItem propItemLong = targetImg.GetPropertyItem(4);
                return ExifGpsToDouble(propItemRef, propItemLong);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
        private static double ExifGpsToDouble(PropertyItem propItemRef, PropertyItem propItem)
        {
            double degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
            double degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
            double degrees = degreesNumerator / (double)degreesDenominator;

            double minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
            double minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
            double minutes = minutesNumerator / (double)minutesDenominator;

            double secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
            double secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
            double seconds = secondsNumerator / (double)secondsDenominator;


            double coorditate = degrees + (minutes / 60d) + (seconds / 3600d);
            string gpsRef = System.Text.Encoding.ASCII.GetString(new byte[1] { propItemRef.Value[0] }); //N, S, E, or W
            if (gpsRef == "S" || gpsRef == "W")
                coorditate = coorditate * -1;
            return coorditate;
        }

        private void lstFilledFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = lstFilledFiles.SelectedItem.ToString();
                Clipboard.SetData(DataFormats.StringFormat, s);
            }
        }

        private void btnRemoveFilesWithDate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstFilledFiles.Items.Count; i++)
            {
                for (int j = 0; j < lstFiles.Items.Count; j++)
                {
                    var filename = lstFilledFiles.Items[i].ToString();
                    var eof = filename.IndexOf("\t");
                    filename = filename.Substring(0, eof);

                    if (filename == Path.GetFileName(lstFiles.Items[j].ToString()))
                    {
                        lstFiles.Items.Remove(lstFiles.Items[j]);
                    }

                }
            }
            lblFilesCount.Text = lstFiles.Items.Count.ToString() + " file(s) selected";
        }
    }
}
