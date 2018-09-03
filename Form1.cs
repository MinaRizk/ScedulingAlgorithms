using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sceduling_Algorithms
{
   
    public partial class Form1 : Form
    {
        const int noOfAlgorithms = 6;
        string[] Algorithms = {"FCFS","SJF (Preemptive)","SJF (Non Preemptive)","Priority (Preemptive)","Priority (Non Preemptive)","Round Robin"};
        /*-------------------------------Form1----------------------------------------*/
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            //disable add process button by default until the required fields is entered
            button3.Enabled = false;
            //change the color of the "*" before the required fields to red
            label5.ForeColor = Color.Red; 
            label6.ForeColor = Color.Red;
            label7.ForeColor = Color.Red;
            label8.ForeColor = Color.Red;
            //make the "*" after the priority field invisible until the priority algorithms are selected
            label8.Visible = false;
            //disble the "start scheduling" button till processes are entered
            button1.Enabled = false;
            //disable "edit selected process" button till a process is selected
            button5.Enabled = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
        }
        /*--------------------------------------------------------Data Structure Section-------------------------------------------------*/
        //creating a struct called process to hold the process attributes
        public struct process
        {
            public int arrivalTime;
            public int burstTime;
            public int priority;
            public int id;
            //constructor
            public process(int a, int b, int p = 0 , int q=0)
            {
                arrivalTime = a;
                burstTime = b;
                priority = p;
                id = q;
            }
        }
        //creating a list of the processes
        List<process> listOfProcesses = new List<process>();


        public struct print
        {
            public int id;
            public int start;
            public int finish;
            public print(int a, int b, int d)
            {
                id = a;
                start = b;
                finish = d;
            }
        }
        public static List<print> listToPrint = new List<print>();
        void initiateListToPrint()
        {
            listToPrint.Add(new print(1, 0, 10));
            listToPrint.Add(new print(-1, 10, 12));
            listToPrint.Add(new print(3, 12, 15));
            listToPrint.Add(new print(4, 15, 50));

        }
        //*************************************************************************************************************************************

        /*-----------------------------------ComboBox of the Algorithms----------------------------------------------------------*/
        //this fn return 1 if an item is selected from the comboBox1(algorithm selection)
        Boolean itemIsSelected()
        {
            //if no item is selected the inddex is -1
            if (comboBox1.SelectedIndex != -1)
                return true;
            else
                return false;

        }
        //this fn returns true if the selected algorithm is one of the priority algorithms
        Boolean prioritySelected()
        {
            if (itemIsSelected())
            {
                int selectedAlgorithmIndex = comboBox1.SelectedIndex;

                //3 and 4 are the numbers of the priority algorithms in the comboBox
                if (selectedAlgorithmIndex == 3 || selectedAlgorithmIndex == 4)
                    return true;
            }

            return false;

        }
        /*--------------comboBox1:algorithm selection---------------------------*/

        //Enabling button3 (add process) if the required fields is entered every time we select an algorithm from the comboBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listOfProcesses.Count != 0)
                button1.Enabled = true;
            //make "add process" button disabled by default
            button3.Enabled = false;
            if (prioritySelected())
            {
                //showing the "*" after the priority field
                label8.Visible = true;
                //if all the required textboxes are written in it make the add process button enabled
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                    button3.Enabled = true;
            }
            else
            {
                //hiding the "*" after the priority field
                label8.Visible = false;
                //if all the required textboxes are written in it make the add process nutton enabled
                if (textBox1.Text != "" && textBox2.Text != "")
                    button3.Enabled = true;
            }
        }
        //*****************************************************************************************************************************************

        


        /*--------------------------------------------------------------------TextBox section--------------------------------------------------------*/
        /*--------------------textBox1:arrival time-----------------------*/


        //check if we should enable button3 (add process) every time text changes in the textBox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //"add process" button is disabled by default
            button3.Enabled = false;
            //check that the user choose an algorithm and all the required fields is not empty
            if (itemIsSelected() && textBox1.Text != "" && textBox2.Text != "")
            {
                //if priority algorithm is selected we check for the priority field is not empty
                if (prioritySelected())
                {
                    //check the priority field is not empty
                    if (textBox3.Text != "")
                        button3.Enabled = true;
                    else
                        button3.Enabled = false;
                }
                //if another algorithm then the higher level if is enough to make the button enabled
                else
                    button3.Enabled = true;
            }
            //if the user did not choose an algorithm or the burst time is empty make the "add process" button disabled
            else
                button3.Enabled = false;
        }

        //click add process button if we press Enter key while typing in the textBox
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button3.PerformClick();
            }
        }
        
       

        /*----------------------------textBox2:burst time--------------------------------*/
        //check if we should enable button3 (add process) every time text changes in the textBox
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //"add process" button is disabled by default
            button3.Enabled = false;
            //check that the user choose an algorithm and all the required fields is not empty
            if (itemIsSelected() && textBox1.Text != "" && textBox2.Text != "")
            {
                //if priority algorithm is selected we check for the priority field is not empty
                if (prioritySelected())
                {
                    //check the priority field is not empty
                    if (textBox3.Text != "")
                        button3.Enabled = true;
                    else
                        button3.Enabled = false;
                }
                //if another algorithm then the higher level if is enough to make the button enabled
                else
                    button3.Enabled = true;
            }
            //if the user did not choose an algorithm or the burst time is empty make the "add process" button disabled
            else
                button3.Enabled = false;
        }

        //click add process button if we press Enter key while typing in the textBox
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button3.PerformClick();
            }
        }

        /*-------------------------------textBox3:priority-------------------------------------------*/
        //check if we should enable button3 (add process) every time text changes in the textBox
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //"add process" button is disabled by default
            button3.Enabled = false;
            //check that the user choose an algorithm and all the required fields is not empty
            if (itemIsSelected() && textBox1.Text != "" && textBox2.Text != "")
            {
                //if priority algorithm is selected we check for the priority field is not empty
                if (prioritySelected())
                {
                    //check the priority field is not empty
                    if (textBox3.Text != "")
                        button3.Enabled = true;
                    else
                        button3.Enabled = false;
                }
                //if another algorithm then the higher level if is enough to make the button enabled
                else
                    button3.Enabled = true;
            }
            //if the user did not choose an algorithm or the burst time is empty make the "add process" button disabled
            else
                button3.Enabled = false;
        }

        //click add process button if we press Enter key while typing in the textBox
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button3.PerformClick();
            }
        }
        //*********************************************************************************************************************************************

        /*-------------------------------------------------------------------Buttons section--------------------------------------------------------*/

        Boolean validEditing()
        {
            string arrivalTime = textBox6.Text;
            string burstTime = textBox7.Text;
            string priority = textBox8.Text;
            try
            {
                //convert string to int
                int arrive = int.Parse(arrivalTime);
                int burst = int.Parse(burstTime);
                //check the validity of the priority if the priority algorithm is selected or the user enters any data in it
                if (prioritySelected() || priority != "")
                {
                    int pri = int.Parse(priority);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        //this fn returns true if the data entered in the textBoxes is valid numbers
        Boolean validInputs()
        {

            string arrivalTime = textBox1.Text;
            string burstTime = textBox2.Text;
            string priority = textBox3.Text;
            try
            {
                //convert string to int
                int arrive = int.Parse(arrivalTime);
                int burst = int.Parse(burstTime);
                //check the validity of the priority if the priority algorithm is selected or the user enters any data in it
                if (prioritySelected()||priority!="")
                {
                    int pri = int.Parse(priority);
                }
                return true;
            }

            catch
            {
                return false;
            }
        }
        /*----------------------------------------------------button3:Add process--------------------------------*/
        //make a process from the entered information and add it to the listView2       
        int numberOfProcesses = 0;//it is the number of entered processes
        private void button3_Click(object sender, EventArgs e)
        {
            //checks if the entered information is valid
            if (validInputs())
            {
                
                button1.Enabled = true;
                //increase the number of entered processes
                numberOfProcesses++;
                string processNumber = numberOfProcesses.ToString();
                //creating a new listView item (lvi1) and add the process number to it's first column
                ListViewItem lvi1 = new ListViewItem(processNumber);
                //add the arrival time to the second column
                lvi1.SubItems.Add(textBox1.Text);
                //add the burst time to the third column
                lvi1.SubItems.Add(textBox2.Text);
                //add the priority to the fourth column
                //there is a bug here as i add the text in the priority textbox without validate it
                lvi1.SubItems.Add(textBox3.Text);
                //adding the new listview item that we have created to the listView2
                listView2.Items.Add(lvi1);
                //adding the process to the listOfProcesses list
                int arrivalTime = int.Parse(textBox1.Text.ToString());
                int burstTime = int.Parse(textBox2.Text.ToString());
                int priority;
                //checks if the textBox3 of the priority is empty which means that the selected algorithm is not priority and the user did not enter info for the priority
                if(textBox3.Text.ToString()=="")
                {
                    //give the priority a zero default value
                    priority = 0;
                }
                //otherwise take the priority entered
                else
                {
                    priority = int.Parse(textBox3.Text.ToString());
                }
                //make a new process and adding it to the listOfProcesses
                listOfProcesses.Add(new process(arrivalTime, burstTime, priority));
                //empty the textBoxes after adding the current process for adding the new inputs
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            //show an error message if the user enters a wrong process information
            else
            {
                MessageBox.Show("Please enter a valid inputs", "ERROR");
            }
            //select textBox1(arrival time) after adding the current process so that the user can enters the next proccess info quickly without using mouse
            textBox1.Select();
        }

        int flag = 0;//turns 1 after 1st click on start scheduling button
        TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
        /*--------------------------------------button1:start sceduling------------------------------------*/
        private void button1_Click(object sender, EventArgs e)
        {
            
            //make a copy to start processing the data 
            process[] processes = new process[numberOfProcesses];
            process[] processes2 = new process[numberOfProcesses];
            listOfProcesses.CopyTo(processes);
            listOfProcesses.CopyTo(processes2);
            //make some changes to data to start
            for (int j = 0; j < numberOfProcesses; j++)
            {
                processes[j].id = 1 + j;//first id is 1 if->++ or else it is 0 if->nothing
                processes2[j] = processes[j];
            }
            //  processes[numberOfProcesses-1].id = numberOfProcesses;
            //  make sure that the data is right
            // Console.WriteLine("list");
            // for (int j = 0; j < numberOfProcesses; j++)
            //{
            //   Console.WriteLine(processes[j].id + "  " + processes[j].arrivalTime + "  " + processes[j].burstTime + "  " + processes[j].priority);
            //  ++id to delete the zero offset 
            // }
            // Console.WriteLine("start processing");
            //  making some calc. to aid in the data processing
            int numberOfProcesses2 = numberOfProcesses;
            float avwait = 0, avturnaround = 0;
            int currenttime = 0, totaltime = 0;
            Array.Sort<process>(processes, (x, y) => x.arrivalTime.CompareTo(y.arrivalTime));
            for (int j = 0; j < numberOfProcesses; j++)
            {
                if (j == 0)
                {
                    currenttime = processes[j].arrivalTime;
                    totaltime = processes[j].arrivalTime;
                }
                totaltime += processes[j].burstTime;
            }
            // output array to be printed
            List<print> finishlist = new List<print>();
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    FCFS(processes, numberOfProcesses, ref listToPrint, currenttime);
                    break;
                case 1:
                    sjfprem(processes, numberOfProcesses, ref listToPrint, totaltime, currenttime);
                    
                    break;
                case 2:
                    sjfNprem(processes, numberOfProcesses, ref listToPrint, totaltime, currenttime);
                    
                    break;
                case 3:
                    priorityprem(processes, numberOfProcesses, ref listToPrint, totaltime, currenttime);
                    break;
                case 4:
                    priorityNprem(processes, numberOfProcesses, ref listToPrint, totaltime, currenttime);
                    break;
                case 5:
                    roundrobin(processes, numberOfProcesses, ref listToPrint, totaltime, currenttime,5);
                    break;
            }

            calculatons(processes2, numberOfProcesses, listToPrint, ref avwait, ref avturnaround);
            textBox4.Text = avwait.ToString();
            textBox5.Text = avturnaround.ToString();

            //output here are
            // list -> finishlist
            // avwait
            //avturnaround

            //----------------------Gantt chart drawing-------------------------------
           // Form2 form2 = new Form2();
            //form2.ShowDialog();
            /*
            if (flag==0)
            {
                
                form2.ShowDialog();
            }
            else
            {
                form2.Close();
                form2.ShowDialog();
            }
            */
            //TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            if(flag==1)
            {
                this.Refresh();
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.RowStyles.Clear();
                tableLayoutPanel1.ColumnStyles.Clear();
            }
            tableLayoutPanel1.Location = new System.Drawing.Point(50, 466);
            
            //tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.Name = "TableLayoutPanel1";
            //const int layoutWidth = 500;
            //tableLayoutPanel1.Size = new System.Drawing.Size(layoutWidth, 500);
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            Controls.Add(tableLayoutPanel1);

           // initiateListToPrint();
            int startingTime = listToPrint[0].start;
            int finishTime = listToPrint[listToPrint.Count() - 1].finish;
            int totalTime = finishTime-startingTime;
            
            // Add rows and columns
            tableLayoutPanel1.ColumnCount = listToPrint.Count();
            //tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            //tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            //tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            Label[] labels = new Label[listToPrint.Count()];
            Label[] startLabel= new Label[listToPrint.Count()];
            Label[] finishLabel= new Label[listToPrint.Count()];
            Panel[] panels = new Panel[listToPrint.Count()];
            //int totalsize = 0;
            for (int i=0;i<listToPrint.Count();i++)
            {
                //1st row
                labels[i] = new Label();
                if (listToPrint[i].id == -1)
                    labels[i].Text = "IDLE";
                else
                    labels[i].Text = "P"+listToPrint[i].id.ToString();
                //labels[i].BackColor = Color.Green;
                //labels[i].MinimumSize = new Size(50, 0);
                //labels[i].AutoSize = true;
                labels[i].Dock = DockStyle.Fill;
                //labels[i].Anchor = AnchorStyles.None;
                labels[i].TextAlign = ContentAlignment.MiddleCenter;
                tableLayoutPanel1.Controls.Add(labels[i], i, 0);
                int burstTime = listToPrint[i].finish - listToPrint[i].start;
                
              

                float timePercentage = ((float)burstTime / totalTime) * 100;

                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,timePercentage));
                //tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,50));
                //2nd row
                panels[i] = new Panel();
                //panels[i].BackColor = Color.Yellow;
                panels[i].Dock = DockStyle.Fill;
                startLabel[i] = new Label();
                startLabel[i].Text = listToPrint[i].start.ToString();
                startLabel[i].BackColor = Color.Blue;
                //startLabel[i].Dock = DockStyle.Left;
                startLabel[i].Dock = DockStyle.Bottom;
                startLabel[i].AutoSize = true;
                
                panels[i].Controls.Add(startLabel[i]);
                //startLabel[i].Anchor = AnchorStyles.Left | AnchorStyles.Bottom;


                finishLabel[i] = new Label();
                finishLabel[i].BackColor = Color.Red;
                finishLabel[i].Text = listToPrint[i].finish.ToString();
                finishLabel[i].TextAlign = ContentAlignment.TopRight;
                
                //finishLabel[i].TextAlign = ContentAlignment.MiddleCenter;
                panels[i].Controls.Add(finishLabel[i]);
                //finishLabel[i].Anchor = AnchorStyles.Right;
                //finishLabel[i].Dock = DockStyle.Bottom;
                finishLabel[i].Dock = DockStyle.Right ;
                //finishLabel[i].Dock = DockStyle.Bottom;
                //finishLabel[i].Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                //finishLabel[i].Anchor = AnchorStyles.Right;
                finishLabel[i].AutoSize = true;
                //panels[i].MinimumSize = new Size(startLabel[i].Width + finishLabel[i].Width, 0);
                tableLayoutPanel1.Controls.Add(panels[i], i, 1);
                //tableLayoutPanel1.ColumnStyles[i].Width = panels[i].Width;
                //tableLayoutPanel1.MinimumSize = new Size(panels[i].Width, 0);
                //totalsize += panels[i].Width;
                //tableLayoutPanel1.MinimumSize = new Size(totalsize, 0);


                //panels[i].AutoSize = true;
                tableLayoutPanel1.MinimumSize = new Size(800, 0);
                tableLayoutPanel1.MaximumSize = new Size(1200, 0);
                tableLayoutPanel1.AutoSize = true;
                //tableLayoutPanel1.AutoScroll = false;
                //tableLayoutPanel1.VerticalScroll.Enabled = false;
                
                tableLayoutPanel1.AutoScroll = true;
                if(tableLayoutPanel1.VerticalScroll.Enabled==true)
                    tableLayoutPanel1.Height =120;

                
                //tableLayoutPanel1.VerticalScroll.Enabled = false;
                //int vertScrollWidth = SystemInformation.HorizontalScrollBarHeight;

                //tableLayoutPanel1.Padding = new Padding(0, 0, vertScrollWidth, 0);
                //tableLayoutPanel1.Controls.Add(finishLabel[i], i, 1);

            }
            //tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            //tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            //tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            listToPrint.Clear();
            flag = 1;
            
            /*
            label9.BackColor = Color.Red;
            label9.Anchor = AnchorStyles.None;
            label9.TextAlign = ContentAlignment.MiddleCenter;
            tableLayoutPanel1.Controls.Add(label9, 0, 0);
            Label label10 = new Label();
            label10.Text = "p2";
            tableLayoutPanel1.Controls.Add(label10, 1, 0);
            */

        }





        /*******************************this function is for turnaround time and waiting time**************/
        /****
        // it takes the list of any algorthism and the array of processes and number of processes 
        // calculate the average waiting time and the average turn around time 
        // it depends on the two rules:
        //turnaround = completion - arival 
        //waiting = turnaround - burst
        //and average is the sum/total number
        *****/
        static void calculatons(process[] processes, int numberOfProcesses, List<print> finishlist, ref float AvWait, ref float AvTurnAround)
        {
            int[] turnaround = new int[numberOfProcesses];
            int[] waiting = new int[numberOfProcesses];
            int completiontime = 0;
            for (int i = 0; i < numberOfProcesses; i++)
            {
                completiontime = completetime(processes[i].id, finishlist);
                turnaround[i] = completiontime - processes[i].arrivalTime;
                waiting[i] = turnaround[i] - processes[i].burstTime;
            }
            //calc the avg  turn around and waiting time
            //first the sum
            for (int j = 0; j < numberOfProcesses; j++)
            {
                AvWait += waiting[j];
                AvTurnAround += turnaround[j];
            }
            // then the avg
            AvTurnAround = AvTurnAround / numberOfProcesses;
            AvWait = AvWait / numberOfProcesses;
//            Console.WriteLine("start");
  //          Console.WriteLine("avg wait is " + AvWait + " avg turn is " + AvTurnAround);
    //        Console.WriteLine("end");
        }
        /******************************************the helper functions**************************************/
        // this function returns the finish time of a specific id
        static int completetime(int id, List<print> finishlist)
        {
            //searches from behind to see when did this proceess finished
            for (int i = finishlist.Count() - 1; i >= 0; i--)
            {
                if (finishlist[i].id == id)
                    return finishlist[i].finish;
            }
            return -1;
        }
        // this function removes an element from an array without disterbing it's sorting
        static process[] RemoveAt(process[] source, int index, ref int n)
        {
            process[] dest = new process[n - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < n - 1)
                Array.Copy(source, index + 1, dest, index, n - index - 1);

            n--;
            return dest;
        }
        // this function confirms whether an element is the smallest in arriveral time
        static bool IsMinim(process[] listofprocesses, int element, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (listofprocesses[i].arrivalTime < element)
                    return false;
            }
            return true;
        }





        /***************************************************the algo.***************************************/



        /*****
        //at first the FcFs
        //this function takes an array of the processes and the noofprocesses
        //returns a list of the processes sorted in the fcfs with id and start time and finish time
        *****/
        static void FCFS(process[] processes, int numberOfProcesses, ref List<print> output, int currenttime)
        {
            //Console.WriteLine("/********fcfs********/");
            // at first sort//sort according to arriver time
            Array.Sort<process>(processes, (x, y) => x.arrivalTime.CompareTo(y.arrivalTime));
            //get the first gap idle in the processor
            if (currenttime != 0)
            {//the first gap in the processor
                print itemm;
                itemm.id = -1;
                itemm.finish = currenttime;
                itemm.start = 0;
                output.Add(itemm);
            }
            for (int i = 0; i < numberOfProcesses; i++)
            {
                print item;
                if (i == 0)
                {//handle the first arriver to the processor 
                    //and if thier is any gap it is okay as it has been handled
                    currenttime = processes[i].burstTime + processes[i].arrivalTime;
                    item.id = processes[i].id;
                    item.finish = currenttime;
                    item.start = processes[i].arrivalTime;
                    output.Add(item);
                }
                else
                {
                    if (processes[i].arrivalTime <= currenttime)
                    {//handle the waiting processes
                        item.start = currenttime;
                        currenttime += processes[i].burstTime;
                        item.id = processes[i].id;
                        item.finish = currenttime;
                        output.Add(item);
                    }
                    else
                    {//handle the gaps in betwwen processes
                        item.id = -1;
                        item.start = currenttime;
                        item.finish = processes[i].arrivalTime;
                        currenttime = processes[i].arrivalTime;
                        output.Add(item);

                        item.start = currenttime;
                        currenttime += processes[i].burstTime;
                        item.id = processes[i].id;
                        item.finish = currenttime;
                        output.Add(item);
                    }
                }
                //Console.WriteLine(processes[i].id + "  " + processes[i].arrivalTime + "  " + processes[i].burstTime + "  " + processes[i].priority);
            }
        }
        /*****
        //at second the priority non premetive
        //this function takes an array of the processes and the noofprocesses
        //returns a list of the processes sorted in the priority non premetive with id and start time and finish time
        *****/
        static void priorityNprem(process[] processes, int numberOfProcesses, ref List<print> finishlist, int totaltime, int currenttime)
        {
            //Console.WriteLine("/*********priorityNprem********/");
            if (currenttime != 0)
            {//the first gap in the processor
                print itemm;
                itemm.id = -1;
                itemm.finish = currenttime;
                itemm.start = 0;
                finishlist.Add(itemm);
            }
            //calculating the actual total time
            totaltime = real_totaltime(processes, numberOfProcesses, currenttime);
            //sorting according to the priorty
            Array.Sort<process>(processes, (x, y) => x.priority.CompareTo(y.priority));
            //Console.WriteLine(totaltime);
            for (int i = 0; currenttime < totaltime;)
            {
                if (processes[i].arrivalTime <= currenttime)
                {//IsMinim(processes, processes[i].arrivalTime, numberOfProcesses) ||
                    print item;
                    item.id = processes[i].id;
                    item.start = currenttime;
                    item.finish = currenttime + processes[i].burstTime;
                    currenttime += processes[i].burstTime;
                    finishlist.Add(item);
                    processes = RemoveAt(processes, i, ref numberOfProcesses);
                    if (numberOfProcesses == 0)
                        break;
                    Array.Sort<process>(processes, (x, y) => x.arrivalTime.CompareTo(y.arrivalTime));
                    if (processes[0].arrivalTime > currenttime)
                    {//that means that there is a gap so 
                        print itemm;
                        itemm.id = -1;
                        itemm.finish = processes[0].arrivalTime;
                        itemm.start = currenttime;
                        finishlist.Add(itemm);
                        currenttime = processes[0].arrivalTime;
                    }
                    Array.Sort<process>(processes, (x, y) => x.priority.CompareTo(y.priority));
                    i = 0;
                    //  if (numberOfProcesses == 0)
                    //    break;
                }
                else
                {

                    i = (i + 1) % numberOfProcesses;
                }



            }



        }
        static int real_totaltime(process[] processes, int numberOfProcesses, int currenttime)
        {
            for (int i = 0; i < numberOfProcesses; i++)
            {
                if (i == 0)
                {//handle the first arriver to the processor 
                    //and if thier is any gap it is okay as it has been handled
                    currenttime = processes[i].burstTime + processes[i].arrivalTime;
                }
                else
                {
                    if (processes[i].arrivalTime <= currenttime)
                    {//handle the waiting processes
                        currenttime += processes[i].burstTime;
                    }
                    else
                    {//handle the gaps in betwwen processes
                        currenttime = processes[i].arrivalTime;
                        currenttime += processes[i].burstTime;
                    }
                }
            }
            return currenttime;
        }

        /*****
                //at third the priority premetive
                //this function takes an array of the processes and the noofprocesses
                //returns a list of the processes sorted in the priority non premetive with id and start time and finish time
                *****/

        static void priorityprem(process[] processes, int numberOfProcesses, ref List<print> finishlist, int totaltime, int currenttime)
        {
            //Console.WriteLine("/*****priorityprem*****/");
            if (currenttime != 0)
            {//the first gap in the processor
                print itemm;
                itemm.id = -1;
                itemm.finish = currenttime;
                itemm.start = 0;
                finishlist.Add(itemm);
            }
            //calculating the actual total time
            totaltime = real_totaltime(processes, numberOfProcesses, currenttime);
            //sorting according to the priorty
            Array.Sort<process>(processes, (x, y) => x.priority.CompareTo(y.priority));


            for (int i = 0; currenttime < totaltime;)
            {
                if (processes[i].arrivalTime <= currenttime)//IsMinim(processes, processes[i].arrivalTime, numberOfProcesses) ||
                {
                    print item;
                    if (finishlist.Count() == 0)//finishlist.Count() == numberOfProcesses2||
                    {
                        item.id = processes[i].id;
                        item.start = currenttime;
                        item.finish = currenttime + 1;
                        finishlist.Add(item);
                    }
                    else if (finishlist[finishlist.Count() - 1].id == processes[i].id)
                    {
                        item = finishlist[finishlist.Count() - 1];
                        finishlist.RemoveAt(finishlist.Count() - 1);
                        item.finish++;
                        finishlist.Add(item);
                    }
                    else if (finishlist[finishlist.Count() - 1].id != processes[i].id)
                    {
                        item.id = processes[i].id;
                        item.start = currenttime;
                        item.finish = currenttime + 1;
                        finishlist.Add(item);
                    }
                    processes[i].burstTime--;
                    currenttime++;

                    if (processes[i].burstTime == 0)
                    {
                        processes = RemoveAt(processes, i, ref numberOfProcesses);
                        if (numberOfProcesses == 0)
                            break;

                    }

                    Array.Sort<process>(processes, (x, y) => x.arrivalTime.CompareTo(y.arrivalTime));
                    if (processes[0].arrivalTime > currenttime)
                    {//that means that there is a gap so 
                        print itemm;
                        itemm.id = -1;
                        itemm.finish = processes[0].arrivalTime;
                        itemm.start = currenttime;
                        finishlist.Add(itemm);
                        currenttime = processes[0].arrivalTime;
                    }


                    Array.Sort<process>(processes, (x, y) => x.priority.CompareTo(y.priority));
                    i = 0;
                }
                else
                {
                    i = (i + 1) % numberOfProcesses;

                }
            }
        }




        /****
              //at forth the sjf non premetive
              //this function takes an array of the processes and the no of processes
              //returns a list of the processes sorted in the  sjf non premetive with id and start time and finish time
              ****/

        static void sjfNprem(process[] processes, int numberOfProcesses, ref List<print> finishlist, int totaltime, int currenttime)
        {
            //Console.WriteLine("/*********sjf Nprem********/");
            if (currenttime != 0)
            {//the first gap in the processor
                print itemm;
                itemm.id = -1;
                itemm.finish = currenttime;
                itemm.start = 0;
                finishlist.Add(itemm);
            }
            //calculating the actual total time
            totaltime = real_totaltime(processes, numberOfProcesses, currenttime);
            //sorting according to the burst time
            Array.Sort<process>(processes, (x, y) => x.burstTime.CompareTo(y.burstTime));
            //Console.WriteLine(totaltime);
            for (int i = 0; currenttime < totaltime;)
            {
                if (processes[i].arrivalTime <= currenttime)
                {//IsMinim(processes, processes[i].arrivalTime, numberOfProcesses) ||
                    print item;
                    item.id = processes[i].id;
                    item.start = currenttime;
                    item.finish = currenttime + processes[i].burstTime;
                    currenttime += processes[i].burstTime;
                    finishlist.Add(item);
                    processes = RemoveAt(processes, i, ref numberOfProcesses);
                    if (numberOfProcesses == 0)
                        break;
                    Array.Sort<process>(processes, (x, y) => x.arrivalTime.CompareTo(y.arrivalTime));
                    if (processes[0].arrivalTime > currenttime)
                    {//that means that there is a gap so 
                        print itemm;
                        itemm.id = -1;
                        itemm.finish = processes[0].arrivalTime;
                        itemm.start = currenttime;
                        finishlist.Add(itemm);
                        currenttime = processes[0].arrivalTime;
                    }
                    Array.Sort<process>(processes, (x, y) => x.burstTime.CompareTo(y.burstTime));
                    i = 0;
                    //  if (numberOfProcesses == 0)
                    //    break;
                }
                else
                {
                    i = (i + 1) % numberOfProcesses;
                }
            }
        }




        /****
              //at fifth the sjf premetive
             //this function takes an array of the processes and the no of processes
              //returns a list of the processes sorted in the  sjf  premetive with id and start time and finish time
              ****/

        static void sjfprem(process[] processes, int numberOfProcesses, ref List<print> finishlist, int totaltime, int currenttime)

        {
            //Console.WriteLine("/*****sjfprem*****/");
            if (currenttime != 0)
            {//the first gap in the processor
                print itemm;
                itemm.id = -1;
                itemm.finish = currenttime;
                itemm.start = 0;
                finishlist.Add(itemm);
            }
            //calculating the actual total time
            totaltime = real_totaltime(processes, numberOfProcesses, currenttime);
            //sorting according to the priorty
            Array.Sort<process>(processes, (x, y) => x.burstTime.CompareTo(y.burstTime));


            for (int i = 0; currenttime < totaltime;)
            {
                if (processes[i].arrivalTime <= currenttime)//IsMinim(processes, processes[i].arrivalTime, numberOfProcesses) ||
                {
                    print item;
                    if (finishlist.Count() == 0)//finishlist.Count() == numberOfProcesses2||
                    {
                        item.id = processes[i].id;
                        item.start = currenttime;
                        item.finish = currenttime + 1;
                        finishlist.Add(item);
                    }
                    else if (finishlist[finishlist.Count() - 1].id == processes[i].id)
                    {
                        item = finishlist[finishlist.Count() - 1];
                        finishlist.RemoveAt(finishlist.Count() - 1);
                        item.finish++;
                        finishlist.Add(item);
                    }
                    else if (finishlist[finishlist.Count() - 1].id != processes[i].id)
                    {
                        item.id = processes[i].id;
                        item.start = currenttime;
                        item.finish = currenttime + 1;
                        finishlist.Add(item);
                    }
                    processes[i].burstTime--;
                    currenttime++;

                    if (processes[i].burstTime == 0)
                    {
                        processes = RemoveAt(processes, i, ref numberOfProcesses);
                        if (numberOfProcesses == 0)
                            break;

                    }

                    Array.Sort<process>(processes, (x, y) => x.arrivalTime.CompareTo(y.arrivalTime));
                    if (processes[0].arrivalTime > currenttime)
                    {//that means that there is a gap so 
                        print itemm;
                        itemm.id = -1;
                        itemm.finish = processes[0].arrivalTime;
                        itemm.start = currenttime;
                        finishlist.Add(itemm);
                        currenttime = processes[0].arrivalTime;
                    }


                    Array.Sort<process>(processes, (x, y) => x.burstTime.CompareTo(y.burstTime));
                    i = 0;
                }
                else
                {
                    i = (i + 1) % numberOfProcesses;

                }
            }
        }


        /****** 
        //at sixth the round robin
        //this function takes an array of the processes and the no of processes
        //returns a list of the processes sorted in the  round robin with id and start time and finish time
        ****/



        static void roundrobin(process[] processes, int numberOfProcesses,
            ref List<print> finishlist, int totaltime, int currenttime, int q = 1)
        {
            //            Console.WriteLine("/*****round robin******/");
            if (currenttime != 0)
            {
                print itemm;
                itemm.id = -1;
                itemm.finish = currenttime;
                itemm.start = 0;
                finishlist.Add(itemm);
            }
            //calculating the actual total time
            totaltime = real_totaltime(processes, numberOfProcesses, currenttime);
            //sort to start  
            Array.Sort<process>(processes, (x, y) => x.arrivalTime.CompareTo(y.arrivalTime));
            for (int i = 0; currenttime < totaltime;)
            {
                //Console.WriteLine(processes[i].id);
                print item;
                if (numberOfProcesses == 0)
                    break;
                if (finishlist.Count() >= 1)
                    if (finishlist[finishlist.Count() - 1].id == processes[i].id
                        && processes[i].arrivalTime <= currenttime
                        && processes[i].burstTime != 0
                        )
                    {
                        item = finishlist[finishlist.Count() - 1];
                        finishlist.RemoveAt(finishlist.Count() - 1);
                        item.finish += processes[i].burstTime;
                        currenttime += processes[i].burstTime;
                        processes[i].burstTime = 0;
                        finishlist.Add(item);
                        // break;
                    }
                if (numberOfProcesses == 0)
                    break;
                else if (processes[i].burstTime == 0)
                {
                    processes = RemoveAt(processes, i, ref numberOfProcesses);
                    if (i == numberOfProcesses)
                        i = 0;
                    continue;
                }
                else if (numberOfProcesses == 1)
                {
                    if (finishlist[finishlist.Count() - 1].id == processes[i].id)
                    {
                        item = finishlist[finishlist.Count() - 1];
                        finishlist.RemoveAt(finishlist.Count() - 1);
                        item.finish += processes[i].burstTime;
                        currenttime += processes[i].burstTime;
                        processes[i].burstTime = 0;
                        finishlist.Add(item);
                        break;
                    }
                }
                if (processes[i].arrivalTime <= currenttime)
                {
                    if (processes[i].burstTime < q)
                    {
                        item.id = processes[i].id;
                        item.start = currenttime;
                        item.finish = currenttime + processes[i].burstTime;
                        currenttime += processes[i].burstTime;
                        processes[i].burstTime = 0;
                        finishlist.Add(item);
                        //processes = RemoveAt(processes, i, ref numberOfProcesses);
                    }
                    else if (processes[i].burstTime == q)
                    {
                        item.id = processes[i].id;
                        item.start = currenttime;
                        item.finish = currenttime + q;
                        currenttime += q;
                        processes[i].burstTime = 0;
                        finishlist.Add(item);
                        //processes = RemoveAt(processes, i, ref numberOfProcesses);
                    }
                    else if (processes[i].burstTime > q)
                    {
                        item.id = processes[i].id;
                        item.start = currenttime;
                        item.finish = currenttime + q;
                        currenttime += q;
                        processes[i].burstTime -= q;
                        finishlist.Add(item);
                        i = (i + 1) % numberOfProcesses;
                    }
                }
                else //if(processes[i].arrivalTime > currenttime && i==0)
                {
                    if (i > 0)
                    {
                        i = 0;
                        continue;
                    }
                    item.id = -1;
                    item.start = currenttime;
                    item.finish = processes[i].arrivalTime;
                    currenttime = item.finish;
                    finishlist.Add(item);
                    continue;
                }
            }
            /*
                if (finishlist[finishlist.Count() - 1].id == processes[i].id)
                            {
                                item = finishlist[finishlist.Count() - 1];
                                finishlist.RemoveAt(finishlist.Count() - 1);
                                item.finish += processes[i].burstTime;
                                currenttime += processes[i].burstTime;
                                processes[i].burstTime = 0;
                                finishlist.Add(item);
                                continue;
                            }
                */
        }














        /*-------------------------------button2:clear processes----------------------------*/
        private void button2_Click(object sender, EventArgs e)
        {
            listOfProcesses.Clear();
            listView2.Items.Clear();
            numberOfProcesses = 0;
            button1.Enabled = false;
        }

        //--------------------------------button4:add from file-----------------------------*/
        private void button4_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex!=-1)
                button1.Enabled = true;
            //read from the file and put in array of string 
            string[] lines = System.IO.File.ReadAllLines(@"processes.txt");
            foreach(var line in lines)
            {
                numberOfProcesses++;
                string processNumber = numberOfProcesses.ToString();
                //creating a new listView item (lvi1) and add the process number to it's first column
                ListViewItem lvi1 = new ListViewItem(processNumber);
                string[] numbers = line.Split(' ');
                foreach(var number in numbers)
                {
                    lvi1.SubItems.Add(number);
                }
                //adding the new listview item that we have created to the listView2
                listView2.Items.Add(lvi1);
                //make a new process and adding it to the listOfProcesses
                listOfProcesses.Add(new process(int.Parse(numbers[0]), int.Parse(numbers[1]), int.Parse(numbers[2])));
            }
        }

        //*******************************************************************************************************************************

        
        



        

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        
        

        

        

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        bool editMode = false;
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //enabling "edit selected process" button
            //button5.Enabled = true;
             if(listView2.SelectedItems.Count>0)
             button5.Enabled = true;
             else
             {
                 button5.Enabled = false;
             }
            //disable editMode
            editMode = false;
            //change button text to "edit selected process"
            button5.Text = "Edit selected process";
        }


        private void button5_Click(object sender, EventArgs e)
        {
            //toggling editMode
            editMode = !editMode;
            if(editMode==true)
            {
                //changing button text to "finish editing"
                button5.Text = "Finish Editing";
                
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;

                textBox6.Text = listView2.SelectedItems[0].SubItems[1].Text;
                textBox7.Text = listView2.SelectedItems[0].SubItems[2].Text;
                if (listView2.SelectedItems[0].SubItems[3].Text == "")
                    textBox8.Text = "0";
                else
                    textBox8.Text = listView2.SelectedItems[0].SubItems[3].Text;
                textBox6.Select();
            }
            else
            {
                
                //input checking is missing
                if (validEditing())
                {
                    
                    listView2.SelectedItems[0].SubItems[1].Text = textBox6.Text;
                    listView2.SelectedItems[0].SubItems[2].Text = textBox7.Text;
                    listView2.SelectedItems[0].SubItems[3].Text = textBox8.Text;
                    int selectedProcessIndexInTheList = listView2.SelectedIndices[0];
                    int arrivalTime = int.Parse(textBox6.Text.ToString());
                    int burstTime = int.Parse(textBox7.Text.ToString());
                    int priority;
                    //checks if the textBox3 of the priority is empty which means that the selected algorithm is not priority and the user did not enter info for the priority
                    if (textBox8.Text.ToString() == "")
                    {
                        //give the priority a zero default value
                        priority = 0;
                    }
                    //otherwise take the priority entered
                    else
                    {
                        priority = int.Parse(textBox8.Text.ToString());
                    }
                    //listOfProcesses[selectedProcessIndexInTheList].arrivalTime = int.Parse(textBox6.Text);
                    listOfProcesses[selectedProcessIndexInTheList] = new process(arrivalTime, burstTime, priority);
                    listView2.Items[listView2.SelectedIndices[0]].Selected = false;
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox6.Visible = false;
                    textBox7.Visible = false;
                    textBox8.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                    label13.Visible = false;
                    //change button text to "edit selected process"
                    button5.Text = "Edit selected process";
                }
                else
                {
                    MessageBox.Show("Invalid Editing", "ERROR");
                    editMode = !editMode;
                }
                
            }

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button5.PerformClick();
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button5.PerformClick();
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button5.PerformClick();
            }
        }
    }
}
