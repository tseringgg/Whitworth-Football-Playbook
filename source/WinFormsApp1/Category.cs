﻿namespace WinFormsWithAspose
{
    public class Category
    {
        public string Name { get; set; }
        private List<List<Play>> PaginatedPlays; // List of play "pages" where there are 4 plays to a list

        public int Count 
        {
            get
            {
                return PaginatedPlays.Count;
            }
            private set { } 
        }
        public Category(string name)
        {
            PaginatedPlays = new();
            PaginatedPlays.Add(new List<Play>());
            Count = 0;
            Name = name;

        }
        public void Add(string title, Formation form, List<RouteData> routeData, List<string> players)
        {
            // find first List that doesn't have 4 plays
            int index = 0;
            for(int i = 0; i < PaginatedPlays.Count; i++)
            {
                index = i;
                if (PaginatedPlays[i].Count < 4)
                {
                    break; // skip adding another list
                }
                else if (PaginatedPlays[i].Count == 4 && i == PaginatedPlays.Count-1)
                {
                    // if on last play list of 4, add new empty list at end, index++
                    PaginatedPlays.Add(new List<Play>());
                    index++;
                }
            }
            // Add to it
            PaginatedPlays[index].Add(new Play(new List<IDiagramGroup>
            {
                new SkillPlayerGroup(title, 0.4, 0.3) // add groups to be drawn
                    .Add("X", form.x_x, form.x_y)
                    .Add("Y", form.y_x, form.y_y)
                    .Add("Z", form.z_x, form.z_y)
                    .Add("Q", form.q_x, form.q_y)
                    .Add("T", form.t_x, form.t_y)
                    .Add("H", form.h_x, form.h_y),
                new CenterFormation(0.4, 0.3, 0.5),
                new RouteGroup(form, routeData, players)
            }));
        }
        public List<Play> GetPlayPage(int index)
        {
            if(index < 0 || index >= PaginatedPlays.Count)
                throw new ArgumentOutOfRangeException("arg: " + index + " range: [0," + (PaginatedPlays.Count - 1) + "]");
            return PaginatedPlays[index]; // returns a list of 4 plays at the particular index
        }
    }
}
