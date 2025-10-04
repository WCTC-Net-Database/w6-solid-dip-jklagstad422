using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using W6_assignment_template.Interfaces;
using W6_assignment_template.Models;

namespace W6_assignment_template.Data
{
    
    public class DataContext : IContext
    {
        
        private List<CharacterBase> _internalCharacters { get; set; } = new List<CharacterBase>();

    
        public IEnumerable<ICharacter> Characters => _internalCharacters.AsEnumerable();
        public IRoom StartingRoom { get; }

        private readonly JsonSerializerOptions _options;

        public DataContext()
        {
   
            StartingRoom = new Room("The Old Library", "Dust motes dance in the faded light.");

            _options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
              
            };

            LoadData();

            if (!_internalCharacters.Any())
            {
                InitializeNewGame();
            }
        }

        private void InitializeNewGame()
        {
            _internalCharacters.Add(new Player("Aragorn", 100, 5, StartingRoom));
            _internalCharacters.Add(new Goblin(50, 1, StartingRoom));
            _internalCharacters.Add(new Ghost(75, 3, StartingRoom));
            SaveData();
        }

        private void LoadData()
        {
            if (!File.Exists("Files/input.json")) return;

            var jsonData = File.ReadAllText("Files/input.json");

      
            var loadedCharacters = JsonSerializer.Deserialize<List<CharacterBase>>(jsonData, _options);

            _internalCharacters = loadedCharacters ?? new List<CharacterBase>();
        }

     
        public void AddCharacter(CharacterBase character)
        {
            _internalCharacters.Add(character);
            SaveData();
        }

        private void SaveData()
        {
   
            var jsonData = JsonSerializer.Serialize(_internalCharacters, _options);
            File.WriteAllText("Files/input.json", jsonData);
        }
    }
}