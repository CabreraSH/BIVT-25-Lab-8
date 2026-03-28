namespace Lab8.Blue
{
    public class Task1
    {
            // Fields / Поля 
            private string _name;
            protected int _votes; // This one is only accessible in Response and child classes
        
            // Propoerties/ Свойства
            public string Name => _name;
            public int Votes => _votes;
        
            // Конструктор
            public Response(string name)
            {
                _name = name;
                _votes = 0;
            }
        
            // Method / Метод
            public virtual int CountVotes(Response[] responses) // "Virtual" means that we can override it in a subclass (like HumanResponse, for example)
            {
                
                int k = 0;
                for (int i = 0; i < responses.Length; i++) /
                {
                    if (responses[i].Name == _name)
                    {
                        k++;
                    }
                }
                
                for (int i = 0; i < responses.Length; i++)
                {
                    if (responses[i].Name == _name)
                    {
                        responses[i]._votes = k;
                    }
                }
                
                _votes = k;
                return _votes;
            }
        
            public virtual void Print()
            {
                return;
            }
        }
     
        public class HumanResponse : Response
        {
            // Поля
            private string _surname;
            
            // Свойства
            public string Surname => _surname;
            
            // Конструктор
            public HumanResponse(string name, string surname) : base(name)
            {
                _surname = surname;
            }
            
            // Методы
            public override int CountVotes(Response[] responses)
            {
                int k = 0;
                for (int i = 0; i < responses.Length; i++) 
                {
                    if (responses[i] is HumanResponse Human && Human.Name == Name && Human.Surname == _surname)
                    {
                        k++;
                    }
                }
                
                for (int i = 0; i < responses.Length; i++)
                {
                    if (responses[i] is HumanResponse Human && Human.Name == Name && Human.Surname == _surname)
                    {
                        Human._votes = k;
                    }
                }
                _votes = k;
                return _votes;
            }
            public override void Print()
            {
                return;
            }
        }
    }
}
