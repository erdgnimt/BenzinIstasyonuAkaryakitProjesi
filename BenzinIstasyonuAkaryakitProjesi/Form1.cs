using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BenzinIstasyonuAkaryakitProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }       
        /*D=DEPO Bilgileri için kullanılacaktır.
         E= Depoya eklenen miktarların temsili için kullanılacaktır.
        F=FİYAT Bilgileri için kullanılacaktır.
        S=SATIŞ Bilgileri için kullanılacaktır.
        */
        double D_Benzin95 = 0, D_Benzin97 = 0, D_Dizel = 0, D_EuroDizel = 0, D_Lpg = 0;
        double E_Benzin95 = 0, E_Benzin97 = 0, E_Dizel = 0, E_EuroDizel = 0, E_Lpg = 0;
        double F_Benzin95 = 0, F_Benzin97 = 0, F_Dizel = 0, F_EuroDizel = 0, F_Lpg = 0;
        double S_Benzin95 = 0, S_Benzin97 = 0, S_Dizel = 0, S_EuroDizel = 0, S_Lpg = 0;
        string[] Depo_Bilgileri;//depo.txt dosyasındaki depo bilgilerini alacağız ve bu diziye aktaracağız.
        string[] Fiyat_Bilgileri;//fiyat.txt dosyasındaki fiyat bilgilerini alacağız ve bu diziye aktaracağız.
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "AKARYAKIT OTOMASYON";//form başlığını düzenledik.
            progressBar1.Maximum = 1000;//progressbarların maximum değerini belirledik. progressbarları 1000 eşit parçaya böldük. Yani depolarımızın kapasitesini 1000 yapmış olduk. 
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            progressBar4.Maximum = 1000;
            progressBar5.Maximum = 1000;
            Txt_Depo_Oku();
            Txt_Depo_Yaz();
            Txt_Fiyat_Oku();
            Txt_Fiyat_Yaz();
            ProgressBar_Guncelle();
            NumericUpDown_Degerleri();
        }        
        private void Txt_Depo_Oku()//depo txt dosyasındaki verileri okumak ve diziye aktarmak için metot oluşturduk.
        {
            Depo_Bilgileri = File.ReadAllLines(Application.StartupPath + "\\depo.txt");//uygulamanın kayıtlı olduğu bin klasörünün içinde depo.txt dosyasındaki bilgileri aldık ve depo bilgileri dizisine atadık."Apllication.StartupPath" bin dosyasına erişmek için kullanıldı.           
            D_Benzin95 = Convert.ToDouble(Depo_Bilgileri[0]);
            D_Benzin97 = Convert.ToDouble(Depo_Bilgileri[1]);
            D_Dizel = Convert.ToDouble(Depo_Bilgileri[2]);
            D_EuroDizel = Convert.ToDouble(Depo_Bilgileri[3]);
            D_Lpg = Convert.ToDouble(Depo_Bilgileri[4]);//depo.txt den aldığımız sayıları sırayla ilgili değişkenlere atadık.
        }
        private void Txt_Depo_Yaz()//txt dosyasından aldığımız verileri değişkenlere yukardaki metot ile (txt_depo_oku) atamıştık şimdi onları ilgili bu metotla onları ilgili labellara yazdırıyoruz.
        {
            label6.Text = D_Benzin95.ToString();
            label7.Text = D_Benzin97.ToString();
            label8.Text = D_Dizel.ToString();
            label9.Text = D_EuroDizel.ToString();
            label10.Text = D_Lpg.ToString();
        }
        private void Txt_Fiyat_Oku()//fiyat txt dosyasındaki verileri okumak ve diziye aktarmak için metot oluşturduk.
        {
            Fiyat_Bilgileri=File.ReadAllLines(Application.StartupPath+ "\\fiyat.txt");
            //uygulamanın kayıtlı olduğu bin klasörünün içinde fiyat.txt dosyasındaki bilgileri aldık ve depo bilgileri dizisine atadık."Apllication.StartupPath" bin dosyasına erişmek için kullanıldı.  
            F_Benzin95 = Convert.ToDouble(Depo_Bilgileri[0]);
            F_Benzin97 = Convert.ToDouble(Depo_Bilgileri[1]);
            F_Dizel = Convert.ToDouble(Depo_Bilgileri[2]);
            F_EuroDizel = Convert.ToDouble(Depo_Bilgileri[3]);
            F_Lpg = Convert.ToDouble(Depo_Bilgileri[4]);//depo.txt den aldığımız sayıları sırayla ilgili değişkenlere atadık.
        }
        private void Txt_Fiyat_Yaz()//txt dosyasından aldığımız verileri değişkenlere yukardaki metot ile (txt_fiyat_oku) atamıştık şimdi onları ilgili bu metotla onları ilgili labellara yazdırıyoruz.
        {
            label16.Text = F_Benzin95.ToString("N");//"N": virgülden sonrasını 2 karakterle sınırlamayı sağlamaktadır.
            label17.Text = F_Benzin97.ToString("N");
            label18.Text = F_Dizel.ToString("N");
            label19.Text = F_EuroDizel.ToString("N");
            label20.Text = F_Lpg.ToString("N");
        }
        private void ProgressBar_Guncelle()//Depomuzda ne kadar yakıt varsa onu progressbarlara yazdırmak için metot tanımladık.
        {
            progressBar1.Value = Convert.ToInt32(D_Benzin95);//depo.txt dosyasından gelen ve d_benzin95 değişkenine atadığmız değeri progressbar1'in value değerini atadık. Yani ne depoda ne kadar benzin var ise progressbar o kadar dolu gözükecektir.
            progressBar2.Value = Convert.ToInt32(D_Benzin97);
            progressBar3.Value = Convert.ToInt32(D_Dizel);
            progressBar4.Value = Convert.ToInt32(D_EuroDizel);
            progressBar5.Value = Convert.ToInt32(D_Lpg);
        }
        private void NumericUpDown_Degerleri()//Depomuzda bulunan yakıt miktarı kadar satış yapmamazı sağlayacak metot. Yani numericlerin değeri depomuzdaki yakıt kadar olacaktır.
        {
            numericUpDown1.Maximum = Convert.ToDecimal(D_Benzin95.ToString());//decimal double ile dönüşmediği için önce stringe ardından decimale çevirdik.
            numericUpDown2.Maximum = Convert.ToDecimal(D_Benzin97.ToString());
            numericUpDown3.Maximum = Convert.ToDecimal(D_Dizel.ToString());
            numericUpDown4.Maximum = Convert.ToDecimal(D_EuroDizel.ToString());
            numericUpDown5.Maximum = Convert.ToDecimal(D_Lpg.ToString());
        }
    }
}
