namespace WinFormsWithAspose
{
    public class TagsParser
    {
        public string[] PlaySubstr { get; set; }
        public TagsParser(string[] playSubstr)
        {
            PlaySubstr = playSubstr;
        }
        public void Process(out List<string> playersTagged, out List<string> conceptsInPlay)
        {
            for (int k = 0; k < playSubstr.Length; k++)
            {
                for (int w = 0; w < playSubstr[k].Length; w++)
                {
                    if (playSubstr[k][w] == '&')
                    {
                        playersTagged.Add((playSubstr[k][w - 1].ToString()));
                        conceptsInPlay.Add(playSubstr[k + 1]);
                    }
                }
                if (playSubstr[k] == "BOTH")
                {
                    playersTagged.Add("Y");
                    playersTagged.Add("H");
                    conceptsInPlay.Add(playSubstr[k + 1]);
                    conceptsInPlay.Add(playSubstr[k + 1]);
                }

                else if (playSubstr[k] == "DASH")
                {
                    playersTagged.Add("X");
                    conceptsInPlay.Add("DASH");
                }
                else if (playSubstr[k] == "X" || playSubstr[k] == "H" || playSubstr[k] == "Y" || playSubstr[k] == "Z")
                {
                    playersTagged.Add(playSubstr[k]);
                    conceptsInPlay.Add(playSubstr[k + 1]);
                }
            }
        }
    }
}
