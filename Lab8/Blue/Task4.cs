namespace Lab8.Blue
{
    public class Task4
    {
            // Поля
            private string _name;
            private int[] _scores;
            // Свойства
            public string Name => _name;
            public int[] Scores
            {
                get
                {
                    int[] copy = new int[_scores.Length];
                    Array.Copy(_scores, 0, copy, 0, _scores.Length);
                    return copy;
                }
            }
            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        sum += _scores[i];
                    }
                    return sum;
                }
            }
            // Конструткор
            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }
            // Метод
            public void PlayMatch(int result)
            {
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[^1] = result;
            }
            public void Print()
            {
                return;
            }
        }
        public class ManTeam : Team
        {
            public ManTeam(string name) : base(name)
            {
            }
        }
        public class WomanTeam : Team
        {
            public WomanTeam(string name) : base(name)
            {
            }
        }
        public class Group
        {
            // Поля
            private string _name;
            private Team[] _manteams;
            private Team[] _womanteams;
            private int _kman;
            private int _kwoman;
            
            // Свойства
            public string Name => _name;
            public Team[] ManTeams
            {
                get
                {
                    Team[] copy = new Team[_manteams.Length];
                    Array.Copy(_manteams, copy, _manteams.Length);
                    return copy;
                }
            }
            public Team[] WomanTeams
            {
                get
                {
                    Team[] copy = new Team[_womanteams.Length];
                    Array.Copy(_womanteams, copy, _womanteams.Length);
                    return copy;
                }
            }
            
            // Конструктор
            public Group(string name)
            {
                _name = name;
                _womanteams = new Team[12];
                _manteams = new Team[12];
                _kman = 0;
                _kwoman = 0;
            }
            public void Add(Team team)
            {
                if (team is ManTeam && _kman < 12)
                {
                    _manteams[_kman] = team;
                    _kman++;
                }
                if (team is WomanTeam && _kwoman < 12)
                {
                    _womanteams[_kwoman] = team;
                    _kwoman++;
                }
            }
            public void Add(Team[] teams)
            {
                if (_kwoman >= 12 && teams is WomanTeam || _kman >= 12 && teams is ManTeam)
                {
                    return;
                }
                for (int i = 0; i < teams.Length; i++)
                {
                    Add(teams[i]);
                }
            }
            public void Sort()
            {
                Array.Sort(_manteams, (a, b) => b.TotalScore.CompareTo(a.TotalScore));
                Array.Sort(_womanteams, (a, b) => b.TotalScore.CompareTo(a.TotalScore));
            }
            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");
                int teamCount = size / 2;

                group1.Sort();
                group2.Sort();

                for (int i = 0; i < teamCount && i < group1._kman; i++)
                {
                    result.Add(group1._manteams[i]);
                }
                for (int i = 0; i < teamCount && i < group2._kman; i++)
                {
                    result.Add(group2._manteams[i]);
                }

                for (int i = 0; i < teamCount && i < group1._kwoman; i++)
                {
                    result.Add(group1._womanteams[i]);
                }
                for (int i = 0; i < teamCount && i < group2._kwoman; i++)
                {
                    result.Add(group2._womanteams[i]);
                }

                result.Sort();
                return result;
            }
            public void Print()
            {
                return;
            }
    }

}
