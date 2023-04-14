internal class Program
{
    public static void Main(string[] args)
    {
        string[] A = { "unlock.microvirus.md", "visitwar.com", "visitwar.de", "fruonline.co.uk", "australia.open.com", "credit.card.us" };
        string[] B = { "microvirus.md", "visitwar.de", " piratebay.co.uk", "list.stolen.credit.card.us" };

        var answer = FindGoodHosts(A, B);

        foreach (var i in answer)
        {
            Console.WriteLine(i);
        }
    }

    private static int[] FindGoodHosts(string[] A, string[] B)
    {
        var forbiddenHosts = new HashSet<string>(B);
        var hostsList = new List<int>();

        for (var i = 0; i < A.Length; i++)
        {
            var isForbidden = false;
            var hostString = A[i].Split('.');

            for (int j = hostString.Length - 1; j >= 0; j--)
            {
                var connect = string.Join(".", hostString.Skip(j));
                if (!forbiddenHosts.Contains(connect)) continue;
                isForbidden = true;
                break;
            }

            if (!isForbidden)
            {
                hostsList.Add(i);
            }
        }

        return hostsList.ToArray();
    }
}
