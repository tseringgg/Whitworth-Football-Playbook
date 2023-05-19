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
            //creates strings of players and  cooncepts they'll fun
            playersTagged = new();
            conceptsInPlay = new();
            for (int k = 0; k < PlaySubstr.Length; k++)
            {
                for (int w = 0; w < PlaySubstr[k].Length; w++)
                {
                    //takes care of & edge case
                    if (PlaySubstr[k][w] == '&')
                    {
                        playersTagged.Add((PlaySubstr[k][w - 1].ToString()));
                        conceptsInPlay.Add(PlaySubstr[k + 1]);
                    }
                }
                //both edge case
                if (PlaySubstr[k] == "BOTH")
                {
                    playersTagged.Add("Y");
                    playersTagged.Add("H");
                    conceptsInPlay.Add(PlaySubstr[k + 1]);
                    conceptsInPlay.Add(PlaySubstr[k + 1]);
                }
                //dash edge case
                else if (PlaySubstr[k] == "DASH")
                {
                    playersTagged.Add("X");
                    conceptsInPlay.Add("DASH");
                }
                //takes care of all normal plays
                else if (PlaySubstr[k] == "X" || PlaySubstr[k] == "H" || PlaySubstr[k] == "Y" || PlaySubstr[k] == "Z")
                {
                    playersTagged.Add(PlaySubstr[k]);
                    conceptsInPlay.Add(PlaySubstr[k + 1]);
                }
            }
        }
    }
}
