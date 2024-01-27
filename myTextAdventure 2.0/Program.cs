using System.Text;

namespace myTextAdventure
{

    class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public List<obj?> Inv { get; set; } //player with name, health, and nullable list for inv

        public Player(string name, int health, List<obj?>? inv)
        {
            Name = name;
            Health = health;
            Inv = inv ?? new List<obj?>();
        }
    }


    class Room
    {
        public string Name { get; set; }//descriptions and names for rooms stored here
        public object Description { get; set; }
        public Room[]? Neighbors { get; set; } //room has nullable array of neigbors as well as one for objects
        public List<obj?> Objs { get; set; }
        public char[,]? Map { get; set; }

        static Room wall = new Room("wall", "you walk over to the wall. this is a wall. fascinating. you walk back to where you came from.", null, null);
        public Room(string name, object description, List<obj?>? objs, char[,] map)
        {
            
            Name = name;
            Description = description;
            Neighbors = new Room[] { wall, wall, wall, wall };
            Objs = objs ?? new List<obj>();
            Map = map;
        }

        public Room(string[] descriptorArray)
        {
            Description = descriptorArray;
        }

        public string getDescriptorAsString()
        {
            if (Description is string str)
            {
                return str;
            }
            else if (Description is string[] array)
            {
                return $"you stand in a room made of {string.Join(", ", array)}.";
            }
            return "error";

        }



        public override string ToString()
        {
            return $"{Name}"; //forced the class to return string rather than aspect location
        }
    }
    class obj
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }//unused Amount attribute, might add later
        public obj(string name, string desc, int amount)
        {
            Name = name;
            Description = desc;
            Amount = amount;
        }
        public override string ToString()
        {
            return $"{Name}";
        }

    }

    class Program
    {
        static obj rope = new obj("rope", "it's a rope", 0);
        static obj crystalBall = new obj("crystal ball", "a magical ball that does stuff... probably", 0);
        static obj quill = new obj("quill", "like a pen but worse", 0);

        //chat gpt added these objects. they have no funtion... yet
        static obj sword = new obj("sword", "a sharp and shiny sword", 0);
        static obj potion = new obj("potion", "a mysterious potion", 0);

        static Room wall = new Room("wall", "you walk over to the wall. this is a wall. fascinating. you walk back to where you came from.", null, null);
        static Room room_1 = new Room("entry room", new string[] { "old stone slabs", "they seem, moist..." }, new List<obj> { sword }, null);
        static Room room_2 = new Room("wood log room", "you stand in a room made of wooden logs.", new List<obj> { rope }, null);
        static Room room_3 = new Room("redstone", "you stand in a room made of red stone.", new List<obj> { rope, rope, rope, rope }, null);
        static Room room_4 = new Room("Whispering Library", "you stand in a dimly lit room with ancient tomes on towering shelves", new List<obj> { crystalBall, quill }, null);

        // chat gpt wrote these rooms
        static Room room_5 = new Room("Enchanted Garden", "you find yourself in a magical garden with vibrant flowers", new List<obj> { potion }, null);
        static Room room_6 = new Room("Dark Cave", "you enter a dark cave with mysterious echoes",new List<obj> { sword, potion }, null);
        static Room room_7 = new Room("Crystal Chamber", "a room filled with sparkling crystals", new List<obj> { crystalBall, potion }, null);
        static Room room_8 = new Room("Lava Pit", "you are at the edge of a fiery pit of lava", new List<obj> { quill, potion }, null);
        static Room room_9 = new Room("Frozen Tundra", "a freezing cold room with icy winds", new List<obj> { rope, sword }, null);
        static Room room_10 = new Room("Sky Observatory", "a room with a telescope for observing the skies", new List<obj> { crystalBall, quill, potion }, null);
        static Room room_11 = new Room("Mystic Altar", "you stand in a room with a mystical altar", new List<obj> { crystalBall, quill, potion }, null);
        static Room room_12 = new Room("Secret Passage", "you discover a hidden passage with dim lighting", new List<obj> { rope, sword }, null);
        static Room room_13 = new Room("Ancient Bridge", "you cross an ancient bridge over a chasm", new List<obj> { potion, quill }, null);
        static Room room_14 = new Room("Ethereal Chamber", "a room filled with ethereal energy", new List<obj> { crystalBall, rope, potion }, null);
        static Room room_15 = new Room("Echoing Chamber", "a chamber with strange echoes", new List<obj> { quill, potion }, null);
        static Room room_16 = new Room("Underground Lake", "you find a serene underground lake", new List<obj> { crystalBall, potion }, null);
        static Room room_17 = new Room("Glowing Cavern", "a cavern illuminated by mysterious glowing crystals", new List<obj> { sword, quill, rope }, null);
        static Room room_18 = new Room("Sandy Oasis", "you discover a small oasis with golden sand", new List<obj> { potion, quill, rope }, null);
        static Room room_19 = new Room("Magma Chamber", "a chamber filled with molten magma", new List<obj> { sword, potion }, null);
        static Room room_20 = new Room("Celestial Observatory", "a room with telescopes and celestial maps", new List<obj> { crystalBall, quill, potion }, null);
        // Room Initialization
        static Stack<string> room_history = new Stack<string>();
        static Room currentState = room_1;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, please input player name: ");
            string pname = Console.ReadLine();
            Console.WriteLine($"Hello {pname}");

            Player p1 = new Player(pname, 90, null);

            //same line = interconnected
            room_1.Neighbors[2] = room_2;   room_2.Neighbors[3] = room_1;

            room_2.Neighbors[1] = room_3;   room_3.Neighbors[0] = room_2;
            room_2.Neighbors[2] = room_5;   room_5.Neighbors[3] = room_2;

            room_3.Neighbors[1] = room_6;   room_6.Neighbors[0] = room_3;
            room_3.Neighbors[3] = room_4;   room_4.Neighbors[2] = room_3;

            room_6.Neighbors[1] = room_7;   room_7.Neighbors[0] = room_6;
            room_6.Neighbors[2] = room_8;   room_8.Neighbors[3] = room_6;
            room_6.Neighbors[3] = room_9;   room_9.Neighbors[2] = room_6;

            room_9.Neighbors[3] = room_10;  room_10.Neighbors[2] = room_9;

            room_10.Neighbors[3] = room_11; room_11.Neighbors[2] = room_10;

            room_11.Neighbors[3] = room_12; room_12.Neighbors[2] = room_11;

            room_12.Neighbors[1] = room_13; room_13.Neighbors[0] = room_12;

            room_13.Neighbors[1] = room_14; room_14.Neighbors[0] = room_13;

            room_14.Neighbors[1] = room_15; room_15.Neighbors[0] = room_14;

            room_15.Neighbors[2] = room_16; room_16.Neighbors[3] = room_15;

            room_16.Neighbors[2] = room_17; room_17.Neighbors[3] = room_16;

            room_17.Neighbors[2] = room_18; room_18.Neighbors[3] = room_17;

            room_18.Neighbors[2] = room_19; room_19.Neighbors[3] = room_18;

            room_19.Neighbors[2] = room_20; room_20.Neighbors[3] = room_19;

            //0. go west 1. go east 2. go north 3. go south
            //N
            //WE
            //S

            Room[] rooms = { room_1, room_2, room_3, room_4, room_5, room_6, room_7, room_8, room_9, room_10, room_11, room_12, room_13, room_14, room_15, room_16, room_17, room_18, room_19, room_20 };
            for (int i = 0; i < rooms.Length; i++)
            {
                mapDraw(rooms[i]);
            }

            //game loop
            while (true)
            {
                currentState = inoitilize(roomOptions(currentState), currentState, p1);

                for (int i = 0; i < rooms.Length; i++)
                {
                    mapDraw(rooms[i]);
                }
            }
        }
        //prompts player for int decisions
        static int roomOptions(Room room)
        {
            //trypeek solves the issue of doubling up room history if player walks to wall

            string resultOfPeek;
            room_history.TryPeek(out resultOfPeek);
            if (resultOfPeek != currentState.Name)
            {
                room_history.Push(currentState.Name);
            }

            string compass = @"
    N    
W       E
    S";

            Console.Write($"{room.getDescriptorAsString()} what would you like to do? \n1. go west\n2. go east\n3. go north\n4. go south\n5. go to inventory\n6. room history\n");
            if (room.Objs.Count != 0)
            {
                Console.WriteLine("the following objects are in the room. if you would like to pick one up, use the following numbers:\n");
            }
            for (int i = 0; i < room.Objs.Count(); i++)
            {
                if (room.Objs[i] != null)
                {
                    Console.WriteLine($"{i + 7}. {room.Objs[i].Name} \n");
                }
            }
            finalFullMap();
            Console.WriteLine(compass);
            string response = Console.ReadLine();
            int a;
            bool res = int.TryParse(response, out a);
            if (res == true)
            {
                return a;
            }

            Console.WriteLine("you clearly can't tell the difference between a number and a letter, so I made a decision for you");
            return 1;
            

        }
        // function misspelt because something was called something similar
        static Room inoitilize(int opt, Room currentRoom, Player play)
        {
            if (currentRoom.Objs.Count + 6 < opt)
            {
                Console.Clear();
                return currentRoom;
            }

            //inventory
            else if (opt == 5 && play.Inv != null)
            {
                Console.Clear();
                for (int i = 0; i < play.Inv.LongCount(); i++)
                {
                    Console.WriteLine($"{play.Inv[i].Name} X {play.Inv[i].Amount}");
                }
                return currentRoom;
            }

            //room history
            else if (opt == 6)
            {
                Console.Clear();
                Stack<string> tempStack = new Stack<string>(room_history); // Create a temporary stack
                Console.WriteLine("you have been to the following rooms so far:");
                while (tempStack.Count > 0)
                {
                    Console.WriteLine(tempStack.Pop());
                }
                return currentRoom;
            }

            //pick up object
            else if (opt > 6 && currentRoom.Objs[opt - 7] != null) //pick up second object, type in number too high = death
            {
                Console.Clear();
                Console.WriteLine($"you picked up a {currentRoom.Objs[opt - 7]}\n\n");
                if (play.Inv.Contains(currentRoom.Objs[opt - 7]))
                {
                    currentRoom.Objs[opt - 7].Amount++;
                }
                else
                {
                    currentRoom.Objs[opt - 7].Amount++;
                    play.Inv.Add(currentRoom.Objs[opt - 7]);
                }

                currentRoom.Objs.Remove(currentRoom.Objs[opt - 7]);

                return currentRoom;
            }

            //change room
            else if (opt < 5 && currentRoom.Neighbors[opt - 1].Name != "wall")
            {
                Console.Clear();

                return currentRoom.Neighbors[opt - 1];
            }

            //if go to wall
            else if (currentRoom.Neighbors[opt - 1].Name == "wall")
            {
                Console.Clear();
                Console.WriteLine(currentRoom.Neighbors[opt - 1].Description);
                return currentRoom;
            }

            //catching un-defined input
            //no else cos i'm gangsta like that
               return currentRoom;

        }
        //creates maps for each room
        static void mapDraw(Room roomToDraw)
        {
            char[,] baseRoom = {
            {'#', '#', '#', '#', '|', ' ', '|', '#', '#', '#', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'=', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '='},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', '#', '#', '#', '|', ' ', '|', '#', '#', '#', '#'}
            };


            char[,] wallRoom = {
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
        };
            //0. go west 1. go east 2. go north 3. go south
            //N
            //WE
            //S
            wall.Map = wallRoom;
            if (roomToDraw.Neighbors[0].Name == "wall")
            {
                baseRoom[2, 0] = '#';
            }
            if (roomToDraw.Neighbors[1].Name == "wall")
            {
                baseRoom[2, 10] = '#';
            }
            if (roomToDraw.Neighbors[2].Name == "wall")
            {
                baseRoom[0, 5] = '#';
                baseRoom[0, 4] = '#';
                baseRoom[0, 6] = '#';
            }
            if (roomToDraw.Neighbors[3].Name == "wall")
            {
                baseRoom[4, 4] = '#';
                baseRoom[4, 5] = '#';
                baseRoom[4, 6] = '#';
            }
            if (roomToDraw == currentState)
            {
                baseRoom[2, 5] = 'o';
            }


            roomToDraw.Map = baseRoom;
        }

        //prototype map writer
        static void mapWrite(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        //the ungodly complex three functions that are required to draw the full maps
        static string fullMap(char[,] cG, int x)
        {
            string result = "";
            for (int i = 0; i < cG.GetLength(1); i++)
            {
                result += cG[x, i];
            }
            return result;
        }
        static string fullMap2(Room[] maps)
        {
            StringBuilder resultBuilder = new StringBuilder(); //more efficient? (internet told me)
            for (int x = 0; x < maps[0].Map.GetLength(0); x++)
            {
                foreach (Room map in maps)
                {
                    if (room_history.Contains(map.Name) != false || map.Name == "wall")
                    {
                        resultBuilder.Append(fullMap(map.Map, x));
                        resultBuilder.Append("  ");
                    }
                    else
                    {
                        resultBuilder.Append(fullMap(wall.Map, x));
                        resultBuilder.Append("  ");
                    }
                   
                }
                resultBuilder.AppendLine();
            }
            string result = resultBuilder.ToString();
            return result;
        }



        static void finalFullMap()
        {
            StringBuilder result = new StringBuilder();
            Room[] maps0 = { room_5, wall, room_8, wall, wall, room_20};
            Room[] maps1 = { room_2, room_3, room_6, room_7, wall, room_19};
            Room[] maps2 = { room_1, room_4, room_9, wall, wall, room_18};
            Room[] maps3 = { wall, wall, room_10, wall, wall, room_17};
            Room[] maps4 = { wall, wall, room_11, wall, wall, room_16};
            Room[] maps5 = { wall, wall, room_12, room_13, room_14, room_15};

            Room[][] mapLists = { maps0, maps1, maps2, maps3, maps4, maps5};
            foreach (Room[] maplist in mapLists)
            {
                result.Append(fullMap2(maplist));


                result.Append("\n");
            }
            string finalResult = result.ToString().TrimEnd();
            Console.Write(finalResult);
        }
    }

}