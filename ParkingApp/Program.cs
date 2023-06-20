using System;

namespace ParkingApp
{
    class Program
    {
        static int CreateSlot()
        {
            Console.WriteLine("Welcome to Parking System DotNet 5.0!");
            string statement = "Please input number slot parking:\n" +
            "format : create parking lot 6";
            Console.WriteLine(statement);
            int slot = 0;
            bool repeat = true;
            while (repeat)
            {
                string note = Console.ReadLine();
                string[] arrayNote = note.Split(' ');
                if (arrayNote[0] == "create")
                {
                    slot = Convert.ToInt32(arrayNote[3]);
                    if (slot > 0)
                    {
                        Console.WriteLine("Created a parking lot with " + arrayNote[3] + " slots");
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("\nwrong input for number slot parking");
                    }
                }
                else
                {
                    Console.WriteLine("\nplease create parking lot first");
                }
            }
            return slot;
        }

        static void MainMenu(int slot)
        {
            string[,] slotVehicleNumbers = new string[slot, 4];
            int restSlot = 0;
            int slotStatus = slot;
            int no = 1;
            bool repeat = true;
            string[] arrayLeave = { };
            string index = "";
            while (repeat)
            {
                string note = Console.ReadLine();
                string[] arrayNote = note.Split(' ');

                if (arrayNote[0] == "park" && slot != 0)
                {
                    bool checkLeave = false;

                    for (int i = slotStatus - 1; i >= 0; i--)
                    {
                        if (slotVehicleNumbers[i, 1] == "leave")
                        {
                            index = slotVehicleNumbers[i, 0];
                            checkLeave = true;
                        }
                    }
                    if (!checkLeave)
                    {
                        arrayNote[0] = Convert.ToString(no);
                        for (int i = 0; i < arrayNote.Length; i++)
                        {
                            slotVehicleNumbers[restSlot, i] = arrayNote[i];
                        }
                        no++;
                        restSlot++;
                        slot--;
                        Console.WriteLine("Allocate slot number: " + restSlot);
                    }
                    else
                    {
                        arrayNote[0] = index;
                        for (int i = 0; i < arrayNote.Length; i++)
                        {
                            slotVehicleNumbers[Convert.ToInt32(index) - 1, i] = arrayNote[i];
                        }
                        slot--;
                        Console.WriteLine("Allocate slot number: " + index);
                    }

                }
                else if (arrayNote[0] == "park" && slot == 0)
                {
                    Console.WriteLine("Sorry, parking lot is full");
                }
                else if (arrayNote[0] == "leave")
                {
                    slotVehicleNumbers[Convert.ToInt32(arrayNote[1]) - 1, 1] = "leave";
                    restSlot--;
                    slot++;
                    Console.WriteLine("Slot number: " + arrayNote[1] + " is free");
                }
                else if (arrayNote[0] == "status")
                {
                    Console.WriteLine("Slot\tRegistration No\tType\tColour");
                    for (int i = 0; i < slotStatus; i++)
                    {
                        if (slotVehicleNumbers[i, 1] == "leave" || slotVehicleNumbers[i, 1] == null)
                        {
                            continue;
                        }
                        string statement = slotVehicleNumbers[i, 0] + "\t" + slotVehicleNumbers[i, 1] + "\t" + slotVehicleNumbers[i, 3] + "\t" + slotVehicleNumbers[i, 2];
                        Console.WriteLine(statement);
                    }

                }
                else if (arrayNote[0] == "type" && arrayNote[3] == "mobil")
                {
                    int countMobil = 0;
                    for (int i = 0; i < slotStatus; i++)
                    {
                        if (slotVehicleNumbers[i, 3] == "mobil")
                        {
                            countMobil++;
                        }
                    }
                    Console.WriteLine(countMobil);
                }
                else if (arrayNote[0] == "type" && arrayNote[3] == "motor")
                {
                    int countMotor = 0;
                    for (int i = 0; i < slotStatus; i++)
                    {
                        if (slotVehicleNumbers[i, 3] == "motor")
                        {
                            countMotor++;
                        }
                    }
                    Console.WriteLine(countMotor);
                }
                else if (arrayNote[0] == "registration" && arrayNote[5] == "odd")
                {
                    for (int i = 0; i < slotStatus; i++)
                    {
                        string noVehicles = slotVehicleNumbers[i, 1];
                        if (Convert.ToInt32(noVehicles[5]) % 2 == 1)
                        {
                            Console.WriteLine(noVehicles);
                        }
                    }
                }
                else if (arrayNote[0] == "registration" && arrayNote[5] == "even")
                {
                    for (int i = 0; i < slotStatus; i++)
                    {
                        string noVehicles = slotVehicleNumbers[i, 1];
                        if (Convert.ToInt32(noVehicles[5]) % 2 == 0)
                        {
                            Console.WriteLine(noVehicles);
                        }
                    }
                }
                else if (arrayNote[0] == "registration" && arrayNote[5] == "colour")
                {
                    bool checkColour = false;
                    for (int i = 0; i < slotStatus; i++)
                    {
                        if (slotVehicleNumbers[i, 2] == arrayNote[6])
                        {
                            Console.WriteLine(slotVehicleNumbers[i, 1]);
                            checkColour = true;
                        }
                    }
                    if (!checkColour)
                    {
                        Console.WriteLine("Not found");
                    }
                }
                else if (arrayNote[0] == "slot" && arrayNote[5] == "colour")
                {
                    bool checkColour = false;
                    for (int i = 0; i < slotStatus; i++)
                    {
                        if (slotVehicleNumbers[i, 2] == arrayNote[6])
                        {
                            Console.WriteLine(slotVehicleNumbers[i, 0]);
                            checkColour = true;
                        }
                    }
                    if (!checkColour)
                    {
                        Console.WriteLine("Not found");
                    }
                }
                else if (arrayNote[0] == "slot" && arrayNote[4] == "number")
                {
                    bool checkColour = false;
                    for (int i = 0; i < slotStatus; i++)
                    {
                        if (slotVehicleNumbers[i, 1] == arrayNote[5])
                        {
                            Console.WriteLine(slotVehicleNumbers[i, 0]);
                            checkColour = true;
                        }
                    }
                    if (!checkColour)
                    {
                        Console.WriteLine("Not found");
                    }
                }
                else if (arrayNote[0] == "exit")
                {
                    repeat = false;
                }
            }
        }

        static void Main(string[] args)
        {

            int slot = CreateSlot();
            MainMenu(slot);

        }
    }
}
