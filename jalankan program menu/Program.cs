internal class Program
{
    private static void Main(string[] args)
    {
        MenuSelection().GetAwaiter().GetResult();
    }

    private static async Task MenuSelection()
    {
        Console.WriteLine("Pilih operasi yang ingin Anda lakukan:");
        Console.WriteLine("1. Tampilkan data dari Web API");
        Console.WriteLine("2. Perbarui data di Web API");
        Console.WriteLine("3. Posting data ke Web API");
        Console.WriteLine("0. Keluar");

        bool isRunning = true;

        while (isRunning)
        {
            Console.Write("Masukkan pilihan Anda: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    await GetDataFromAPI();
                    break;
                case "2":
                    await UpdateDataInAPI();
                    break;
                case "3":
                    await PostDataToAPI();
                    break;
                case "0":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static async Task GetDataFromAPI()
    {
        using (HttpClient client = new HttpClient())
        {
            // Ganti URL dengan URL Web API Anda
            string url = "https://api.example.com/data";

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Data dari Web API:");
                Console.WriteLine(data);
            }
            else
            {
                Console.WriteLine("Gagal mendapatkan data dari Web API. Kode status: " + response.StatusCode);
            }
        }
    }

    private static async Task UpdateDataInAPI()
    {
        Console.WriteLine("Masukkan data yang akan diperbarui:");

        // Lakukan logika pembaruan data ke Web API
        // Ganti kode di bawah ini dengan logika sesuai dengan kebutuhan Anda
        string updatedData = Console.ReadLine();

        using (HttpClient client = new HttpClient())
        {
            // Ganti URL dengan URL Web API Anda
            string url = "https://api.example.com/data";

            HttpResponseMessage response = await client.PutAsync(url, new StringContent(updatedData));

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data berhasil diperbarui di Web API.");
            }
            else
            {
                Console.WriteLine("Gagal memperbarui data di Web API. Kode status: " + response.StatusCode);
            }
        }
    }

    private static async Task PostDataToAPI()
    {
        Console.WriteLine("Masukkan data yang akan diposting:");

        // Lakukan logika posting data ke Web API
        // Ganti kode di bawah ini dengan logika sesuai dengan kebutuhan Anda
        string newData = Console.ReadLine();

        using (HttpClient client = new HttpClient())
        {
            // Ganti URL dengan URL Web API Anda
            string url = "https://api.example.com/data";

            HttpResponseMessage response = await client.PostAsync(url, new StringContent(newData));

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data berhasil diposting ke Web API.");
            }
            else
            {
                Console.WriteLine("Gagal memposting data ke Web API. Kode status: " + response.StatusCode);
            }
        }
    }

}