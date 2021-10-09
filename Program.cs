using System;
// N sayıda yinelenen bir dize döndürmek için string.Concat(Enumerable.Repeat(...,..)) kullanıyoruz.
//bunu kullanmak için System.Linq namespace ihtiyacımız var
using System.Linq;

namespace soru2
{
    //Menu'yu yazdırmak için bir class oluşturuldu
    class Menu
    {
        public void Nav()
        {
            Console.WriteLine("     Menü");
            Console.WriteLine("1- string bir değişkende, string değer substring kullanmadan ara \n" +
                "2- string bir değişkende, string değeri substring kullanarak ara \n" +
                "3- Alfabenin karakterlerini bir string de ara kaç adet geçiyor bul ve çiz\n" +
                "Seçiminiz: ");
        }
    }

    //-	Verilen bir karakter dizininin string nesnesi içerisinde kaç defa bulunduğunu bulmak için bir class oluşturuldu
    class NoSubString
    {
        public void Sonuc(string dizi, string kelime)
        {
            int konum = dizi.IndexOf(kelime);         // konum, dizinde bulunan kelime kaçıncı indekste olduğunu temsil eder
            while (konum != -1)                       //birden fazla aynı kelime varsa dizide while döngü ile kontrol edip ekrana yazdırıyoruz
            {
                Console.WriteLine("Kelime {0} indis: {1}", kelime, konum);
                konum = dizi.IndexOf(kelime, konum + 1);
            }
        }
    }

    //-	Verilen bir karakter dizininin substring() metodunu kullanarak string içerisinde kaç defa geçtiğinin bulmak için bir class oluşturuldu
    class YesSubString
    {
        public void Cevap(string dizi, string kelime)
        {
            //aranan kelimenin uzunluğunu veriyor
            int kelimeUzunluk = kelime.Length;

            //1 den dizi.Length'ye kadar tüm stringleri tek tek kontrol ediyor
            for (int i = 0; i < dizi.Length; i++)
            {
                //i den sonraki kelimenin uzunluğuna kadar karakterden oluşan yeni bir string oluşturulur   (türkçemin için özür dilerim :) )
                string word = dizi.Substring(i, kelimeUzunluk);

                if (word == kelime)         //eğer koşul sağlanırsa ekrana aranan kelimenin indeksini yazdıracak
                {
                    int indeks = dizi.IndexOf(word);

                    while (indeks != -1)      //birden fazla aynı kelime varsa dizide while döngü ile kontrol edip ekrana yazdırıyoruz
                    {
                        Console.WriteLine("Kelime {0} indis: {1}", kelime, indeks);
                        indeks = dizi.IndexOf(kelime, indeks + 1);
                        continue;
                    }
                    break;
                }
            }
        }
    }
    //-	Verilen bir string nesnenin içerisinde Alfabenin karakterlerinin her birinden kaç adet olduğunu bulmak için bir class oluşturuldu
    class Alfabe
    {
        public void KelimeSayilma()
        {
            string harfler = "ABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜVWXYZ";       //ekrana tüm harfleri yazmak için
            char[] arry = harfler.ToCharArray();                       //her karakter kontrolu yapmak için char[] dizi ihtiyacımız var

            Console.WriteLine("---------Metnini yazın---------");
            Console.WriteLine();

            int[] karakter = new int[(int)char.MaxValue];                //karakterlerin sayısı kaydetmek için

            do
            {
                string metin = Console.ReadLine();

                string strng = metin.ToUpper();                 //girildiği değerler büyük karaktere çevrimek için
                foreach (char item in strng)                    //strng bulunan tüm karakterler kontrol ediyor
                {
                    foreach (char harf in arry)                 //arry bulunan tüm karakterler kontrol ediyor
                    {
                        if (item == harf)                       //eğer strng'de aranan karakter arry'de aynı ise koşulunu sağlanıyor
                        {
                            karakter[(int)item]++;              // strng'deki bulunan karakteri int dönüştürüp değerini +1 ile toplanıyor ve o karakter dizi indeksinde atıyor

                        }
                    }
                }

            } while (Console.ReadKey().Key != ConsoleKey.Enter);     //dışarıdan iki kere "Enter" basıncaya kadar consolun anahtarı bir satır aşağıya gider( eğer "Enteré sadece bir kere basılıyorsa)

            Console.WriteLine();
            Console.WriteLine("    Karakter Sayısı      Grafik Gösterimi ");
            Console.WriteLine("--------------------------------------------");

            foreach (char ch in arry)             //arry deki bulunan tüm karakterlerini kontrol eder
            {
                if (char.IsLetter((char)ch))      //eğer ki karakter harf ise ekrana alfabenin harfleri ve herpsini kaç adet olduğunu yazdırır
                {
                    Console.WriteLine("    {0},    sayısı: {1}    {2} ", (char)ch, karakter[ch], string.Concat(Enumerable.Repeat("*  ", karakter[ch])));      //strin.Concat(Enumerable.Repeat()) grafik gösterimi içinn kullanıldı.
                                                                                                                                                              // ekrana birden fazla * yazmak için
                }
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            string cevap;         //dışarıdan alanıcak cevap, eğer terkar yeni bir seçenek seçilmek istenirse

            do
            {
                Menu menu = new Menu();      //Menu classtan menu nesnesini oluşturuldu
                menu.Nav();                  //Menu classtaki bulunan metot çağırıldı

                int secenek = Int32.Parse(Console.ReadLine());         //dışarıdan alınan değer int dönüştürür


                if (secenek == 1)
                {
                    Console.WriteLine("Aralınacak Kelime: ");
                    string kelime = Console.ReadLine();
                    Console.WriteLine("Karakter Dizini: ");
                    string dizi = Console.ReadLine();

                    Console.WriteLine("============================================");

                    NoSubString sayi = new NoSubString();             //NoSubString classtan sayi nesnesi oluşturuldu
                    sayi.Sonuc(dizi, kelime);                         // Sonuc() metodu çağırıldı
                }
                else if (secenek == 2)
                {
                    Console.WriteLine("Aralınacak Kelime: ");
                    string kelime = Console.ReadLine();
                    Console.WriteLine("Karakter Dizini: ");
                    string dizi = Console.ReadLine();

                    Console.WriteLine("============================================");

                    YesSubString yenidizi = new YesSubString();       //YesSubString classtan yenidizi nesnesi oluşturuldu
                    yenidizi.Cevap(dizi, kelime);                     //Cevap() metodu çağırıldı
                }
                else if (secenek == 3)
                {
                    Alfabe alphabet = new Alfabe();                   //Alfabe classtan alphabet nesnesi oluşturuldu
                    alphabet.KelimeSayilma();                         //KelimeSayilma() metodu çağırıldı
                }
                else
                {
                    Console.WriteLine("Yanlış değer girdiniz.");
                }

                Console.Write("Başka bir işlem yapmak istiyor musunuz (E/H)? ");        //eğer yeni bir işlem yapmak istenirse
                cevap = Console.ReadLine().ToUpper();              //dışarıdan cevap alıp büyük harflere çeviriyor(eğer küçük değer girilrse)

                Console.Clear();                //Ekranı ve konsol arabelleğini temizlemek için Clear () yöntemi kullanıldı
            } while (cevap == "E");             //cevap "E" ise döngü devam edecek
                                                //değilse döngüden çıkacak ve program bitecek          
        }
    }
}
