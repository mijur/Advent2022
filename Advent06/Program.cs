internal class Program
{
    private static void Main(string[] args)
    {
        /*
         * 7
         * 6
         * 10
         * 11
         */
        Console.WriteLine("Hello, World!");
        List<string> packets = new List<string>
        {
            "mjqjpqmgbljsphdztnvjfqwrcgsmlb",
            "bvwbjplbgvbhsrlpgdmjqwftvncz",
            "nppdvjthqldpwncqszvftbrmjlhg",
            "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg",
            "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw",
            "mqllsjlslffbqbsbpbcbdbfbfvbfblfltffpddsmmhjmjvmvsmvvjfvfjjfccblbddhrdhrrlcrllrrswwlpwlwwgrglrgllrrlsshffrwfwcffmrrdfdrrncrnnlvllbsbcbwcchsshsrhhbnhbbqbmmmfdfvvqpqlpqppfgpfgpfpfttwrwwwfmfpfpmmpgglwglgfgsfgsggdllfhhmchmhttlhlchhrzrszsqqqzdzrrbbpgpccmfcmcbcdcrdrzzvjjgjfgfqfcqffvbbjbjbjsbjjbhjjzjlzjznzbbjvvpssdfdvffssrffpzfppsddgwgzgccrmrmdrrzpzbbjlbjlbjbgjbjmmtmllqffpjfppzzztfzfzfmfnndmdtmmhgmmsdshdhppbnpnbpnpdndgdbdwdtwwzqqjwjpphnnjddlglzlczzdpdjdjtjtgtqtptrrbqqqspsfswsdwdjdsdcdllpzpqplqqjnjrnnvrrnrccnwnnsttqzqcqppvmvdmdjjpnppljppptpzzwbwrrqgqhghshlslblflhflfbbwhwlhwhbwbdwbdwwzlwzwhzwznwwmmrddlttdrtrsttqbqtqtdqttqwwglwlbbdmbmcbbwbnbtbmbggdqqnhqqptpdtttvcvmvmdmtdttcwclccjcrctcllrprlrqqzqccttgnntstrtqqtfthtghhvcczhhctclljcljlcjcdjcdchhmjmjjrsjszjszsbsqqpfflqffqvfqvqjjnjtthvvvcjcjrcjclcwcrcrjcrchrcrggcjjpjjbwjbwjbwjwsjjrssfggzbgzgzrzmrmwmrrczcppnmnmzzgtglljlhjlhhgzgtgddrrhvvvlhlwhlhzzgzfgzzbvbvrvllplnlqnnfvnvgvdgvddsdqsdscscjjjvrvpptgpgdgtdtdzdtztfzfszfftjftfmftmtftddjzdzssfllfsllpwpwswrwdrwrcclczlclpccdrrftrftrtltftnftfnfrnfrfgfjfttrsrqsshlhdhnnztntwwnwppwbbmrbbtntznzggthghfggttpnpnpbplpvvpmmpwmbgcpwgsfndbrclcwbdcfhlcqblplglnqpnrpjqbddfqlqvbzrtwbwzvwqntcgmzrzztlffzmfmcmfzrmcvfctmlrlbtbpsgddbqrlblsslsbcmcglzdzjzlpgzprbrmfmlzrssqddzfjzfgbpvdgrrnldmtqgtjppqqwtzbltpfgpqtdqpwhbbwblnvvpmnljdghwrbnphswhgcvhpcplbbmwprznzzwnfntfplscpflhwdmlvfwtgrjhchnmnqbfgvsglllnnzwchqtcrvqzzhttcmblcthqrjdbvpwptcqtsnwrnfbbsqlshhtqdvcfcgdlbgzqjvzvglbcdwzpzttjnsvwrdldcqqstnnfnjthncgfvggphgfgstnmvnbmtvhpmsgmrccmmslqmjfzdjnbcjbjnpmsnvmzrphhjrdrrssnclvwbnzvpccqglnpljdtwrlnvpqzlshpcmfnmrjchqvlmthqbdrlnnpwcmfnwfzpbpnrsdmrqgqsjgwttwhgqlwghjntrvdndfhdwfzbwnmbjlzbhhdqfrdtwcjjvfnjbqdmdwncfhmslflvhqdmrcdrcdrldnqdmhzsvlglgflmlhwjqvfjdmqbmgffvdmmsbrrnrlcsbncvsjffttmhnbpwmqrnvdmzhztbbsrtwgfshjnlvhqvzwpvrmqfbsszswvrglnmwlmcdpjvmqsgnjshspzwrwctwwghmgjvbthcqcrlflsnrnpwvbnghrhvzpzchjlcljplflzqdvglgtvczhnbnlqltblddslqmdpvfbstvszqdsjvgfqlmdgbsnlzlrnbbqqfqjfqhljzlpbbgbnchwljjcpzbhdmwfzmqstcwtvgtvwcpgvmhpsngrshjvzzngbhjqmcfgjjzgdzcsbsvfwmznmwnnvlbntvcmgphqmdfjvhrlldcpwgnmbpjlqflvsrwqphvlpzlsdthfzdzvlphzdbqldvggsgrcmmfmfnjsfszqqbhnmntfgrbfwtlpqgwnrcqdsmqpqbtfdsnhbdcbwcdrhrfgsctrnlchrrnlptbcnqhndcpcdrgtznqrbgjlwzsjhblptncwtqcqcbzccrnjcmfvfnzwlrgdtgcvvcprwvnrrbdjzfnlvlqfpgbpwsvcnmnmmhnshtjgrcnscljwncdjqtwhlhvcggnwbzlzvfqmcdhmzddrdhvnnjbzbtnrgqcbmzhzzfldhlwwsgztfhncgctvjvszdzhrqmzvffmhvsqssjjvrrmtwqswhwjqgbfghbgfmgqssfhbcrglnbstfnqzvwqcznzgtnvjdvhtrlmgthcrqcwbjnzddsqhzwmdwndqcplhvpbpsdthngqwmlfqfndfqbpbwwrvsrnsjbsrwjdjbcqcvdfcsscgblggwggtmbntnbmmswfhvzhltwvprdgvzwltchhzsqlpwdndwftmsgbfwbpmhsdjhwbvvpzlpspsrsnpbwtdspfvdqdjfjbzmmtbnpzrqngccrbfndnjbcjfvwjvfjdvmsqdvgctzvpzmjmjvggpqfmmrsvqbrrlwrmzhmhpcmpltwdbtmwgzrrvsdhvhlwzggjwqzpbzvzrdbptzhzcrrjwjmdwdpsfwfspjgtmfcvddgspldbldtbtwrzdsjrbhvvcjgnrsbzvbrnqjwhrzgfsbdjlfqlszvlnrbfcrgfwrsmqmmnrwbtvfdpjzpfbhplfdsrwwgqqtgnzvddbgjjllmmcjjlglwmsbwrdrnnznwzplnbhlrlnmnllwgwgdpqdqqlmvsbgcshsmntrrlrvdhjgctzsfhmvfqtthvvchftflhlqqhhhbhqvgwtcmgcfwldhgptfddpsqrfzqmtpszswfrztzfsspltcvjwwsljsnjpnnqggscwwmcwfrljlrtqwqvplthsctvbndjfpnvcbdngzqtgjvwlsdhthdwmjvtnzrplwzwsfmgszpqjcjttslsmtbbvhjgpqmqfjbcccsnrlwmjhbsqgzqldmlhnbjnjfwmgzpvdcwndbwcncmtzccngcghhpwmjnncfgqtdtzwmhbdrpwsfbnjzfnwzwqncnlfjqjrjhgnqgvbcdhgdnbwpqjcfgprmfhzlrqtwlqpshfrgdszrwdtqfcntrzbgzlvrhtlsbjjwtnlqllnsvbzwjlmqvdgvtslmbwwcfstmqntwwwsjmrflrqnttfzjchpgwczzdtqbhdrtrpvhhbscvjtdtrhbstpqrnrzszwvcqzhbrzhlblvzrgwtqzbslbmgdqhpfqrdqrzcsbglcsshcwvlcpgjtjmcgpmsnldjzlwnrqlzzznpvmgssvzshjvtsmmzvstpqrhfvttnsrddfcqcbwhgpfdtlhcvcgjgdrvvntvdjqpvwvfmphhpzjgmshddqfsbpjbzrfdjnwrhmgcfbccmzqgvrbmcjdpvwfrtdpbwvjtjcrmnpzrrqbbvbsgcplwmlbsdwptbprlczjcqhdzprpttvnthbmtscdtjvrnwqhnvqbzvwnphnzwlgvvjhddjvjrvwlmhqcsffcnhgjzdjppqqwbglbhgzsmvzwjdvbqpztphshtrbrrhzmdlfdtssbhrcltwlqpzvpgbsgngpfjsjbrnnlzctqcqzwswhfnjjngwsztdgmmcffqfhbsgwstnflqjqttzbtgjvcfrrdwzcvhwjnhmtphszrsptjsqqwcwfnmtlzvzsqsmghtztrpvdslrmjqqvwfmzlwwjbwtpmhtqcfctdztsnfrhfqwqcjdzmjhvwwgrslmdqqwgwfvwlzzsznmdrzgcvbmrtcvjsqlftnpdhwmrzjwsnjjdrczbjcwhwlrtljwjsfmcfcrsjflsldbjrzpdgltmhtszzznjjlfqmgpbjfjncvtvlcfsmltbsvsrgdhwwhcpbdbntqhgjztvlwtwdsgqfwtlcdzffcszjmjvj"
        };

        foreach(var packet in packets)
        {
            Console.WriteLine(NumOfCharsToFirstPacket(packet));
        }
    }

    private static int NumOfCharsToFirstPacket(string packet)
    {
        List<char> chars =new();
        int counter = 0;
        int iteration = 0;
        HashSet<char> buff = new HashSet<char>();
        while (iteration<packet.Length-1)
        {
            buff.Add(packet[iteration]);
            counter++;
            iteration++;

            if (counter == 14)
            {
                counter = 0;
                if (buff.Count == 14)
                {
                    break;
                }
                else
                {
                    buff.Clear();
                    iteration -=13;
                }
            }
        }
        return iteration;
    }
}