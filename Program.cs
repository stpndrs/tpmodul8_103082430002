using System;
using tpmodul8_103082430002;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig configManager = new CovidConfig();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {configManager.config.satuan_suhu}: ");
        double suhu = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
        int hariDemam = int.Parse(Console.ReadLine());

        bool suhuValid = false;
        if (configManager.config.satuan_suhu == "celcius")
        {
            suhuValid = (suhu >= 36.5 && suhu <= 37.5);
        }
        else
        {
            suhuValid = (suhu >= 97.7 && suhu <= 99.5);
        }

        bool hariValid = (hariDemam < configManager.config.batas_hari_deman);

        if (suhuValid && hariValid)
        {
            Console.WriteLine(configManager.config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(configManager.config.pesan_ditolak);
        }

        Console.WriteLine("--- Mengubah Satuan Konfigurasi ---");
        configManager.UbahSatuan();
        Console.WriteLine($"Satuan sekarang telah berubah menjadi: {configManager.config.satuan_suhu}");
    }
}