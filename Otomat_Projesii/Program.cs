namespace Otomat_Projesii
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] urunler = new string[] { "Admin", "Cola", "Jelibon", "Çikolata" };
            int[] fiyatlar = new int[] { 1, 20, 10, 60 };
            int gunlukknk = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Lütfen Almak İstediğiniz Ürün İçin Tuşlama Yapınız");

                for (int i = 1; i < urunler.Length; i++)
                {
                    Console.WriteLine($"{i} - {urunler[i]} - {fiyatlar[i]} TL");
                }

                try
                {
                    int secenek = Convert.ToInt32(Console.ReadLine());

                    if (secenek >= 1 && secenek < urunler.Length)
                    {
                        int urunFiyati = fiyatlar[secenek];
                        Console.WriteLine("Lütfen Parayı Yatırınız");
                        int para = Convert.ToInt32(Console.ReadLine());

                        while (para < urunFiyati)
                        {
                            Console.WriteLine("Yetersiz Bakiye Para Eklemek İçin 1 Para İade İçin 2");
                            int secenek1 = Convert.ToInt32(Console.ReadLine());

                            if (secenek1 == 1)
                            {
                                Console.WriteLine("Eklenecek Miktarı Girin");
                                int eklenenPara = Convert.ToInt32(Console.ReadLine());
                                para += eklenenPara;
                            }
                            else if (secenek1 == 2)
                            {
                                Console.WriteLine("Paranız İade Edildi");

                                break;
                            }
                        }

                        if (para >= urunFiyati)
                        {
                            int paraUstu = para - urunFiyati;
                            Console.WriteLine($"Ürününüz Hazır Yandan Alın Para Üstü {paraUstu} tl");
                            gunlukknk += urunFiyati;
                            Thread.Sleep(2000);
                        }
                    }
                    else if (secenek == 0)
                    {
                        Console.WriteLine("Admin Şifresini Giriniz");
                        int hak = 3;
                        string sifre = "ab18";

                        while (hak > 0)
                        {
                            string girilenSifre = Console.ReadLine();
                            hak--;

                            if (girilenSifre == sifre)
                            {
                                Console.WriteLine("Admin Paneline Başarılıyla Giriş Yaptınız");
                                break;
                            }
                            else if (hak == 0)
                            {
                                Console.WriteLine("Otomat Kilitlendi");
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine($"Şifre Yanlış Kalan Hak {hak}");
                            }
                        }


                        while (true)
                        {
                            Console.WriteLine("1 Ürün Ekle");
                            Console.WriteLine("2 Ürün Sil");
                            Console.WriteLine("3 Ürün Güncelle");
                            Console.WriteLine("4 Ürünleri Listele");
                            Console.WriteLine("5 Çıkış");
                            Console.WriteLine("6 Günlük Satış");

                            int adminSecenek = Convert.ToInt32(Console.ReadLine());

                            if (adminSecenek == 1)
                            {
                                Console.WriteLine("Eklenecek Ürün:");
                                string urun = Console.ReadLine();
                                Array.Resize(ref urunler, urunler.Length + 1);
                                urunler[urunler.Length - 1] = urun;
                                Console.WriteLine("Ürünün Fiyatı:");
                                int fiyat = Convert.ToInt32(Console.ReadLine());
                                Array.Resize(ref fiyatlar, fiyatlar.Length + 1);
                                fiyatlar[fiyatlar.Length - 1] = fiyat;
                                Console.WriteLine("Ürün Başarıyla Eklendi.");
                            }
                            else if (adminSecenek == 2)
                            {
                                for (int i = 1; i < urunler.Length; i++)
                                {
                                    Console.WriteLine($"{i} - {urunler[i]} - {fiyatlar[i]} TL");
                                }
                                Console.WriteLine("Silmek İstediğiniz Ürün Numarasını Giriniz:");
                                int urunsıl = Convert.ToInt32(Console.ReadLine());

                                if (urunsıl >= 1 && urunsıl < urunler.Length)
                                {
                                    Array.Clear(urunler, urunsıl, 1);
                                    Array.Clear(fiyatlar, urunsıl, 1);
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.WriteLine("Silmek Başarılı İle Gerçekleşti");
                                }
                                else
                                {
                                    Console.WriteLine("Hatalı Ürün Numarası.");
                                }
                            }
                            else if (adminSecenek == 3)
                            {
                                for (int i = 1; i < urunler.Length; i++)
                                {
                                    Console.WriteLine($"{i} - {urunler[i]} - {fiyatlar[i]} TL");
                                }
                                Console.WriteLine("Güncellemek İstediğiniz Ürün Numarasını Giriniz");
                                int guncellenecek = Convert.ToInt32(Console.ReadLine());

                                if (guncellenecek >= 1 && guncellenecek < urunler.Length)
                                {
                                    Console.WriteLine("Yeni Fiyatı Giriniz");
                                    int yeniFiyat = Convert.ToInt32(Console.ReadLine());
                                    fiyatlar[guncellenecek] = yeniFiyat;
                                    Console.WriteLine("Ürün Fiyatı Güncellendi");
                                }
                                else
                                {
                                    Console.WriteLine("Hatalı Ürün Numarası");
                                }
                            }
                            else if (adminSecenek == 4)
                            {
                                Console.WriteLine("Ürün Listesi");
                                for (int i = 1; i < urunler.Length; i++)
                                {
                                    Console.WriteLine($"{i} - {urunler[i]} - {fiyatlar[i]} TL");
                                }
                            }
                            else if (adminSecenek == 5)
                            {
                                Console.WriteLine("Admin Panelinden Çıkış Yapılıyor.");
                                Thread.Sleep(2000);
                                break;
                            }
                            else if (adminSecenek == 6)
                            {
                                Console.WriteLine($"Günlük Toplam Satış: {gunlukknk} TL");
                            }
                            else
                            {
                                Console.WriteLine("Hatalı Seçim!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hatalı Seçim!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lütfen Geçerli Bir Rakam Giriniz!");

                }
            }
        }
    }















}


