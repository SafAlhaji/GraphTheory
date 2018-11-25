using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTheory
{
    public partial class Form1 : Form
    {
        private Node a, b, c, d, e, f;

        private void button2_Click(object sender, EventArgs e)
        {
            var stack = new Stack<Node>();
            var final = new List<Node>();

            a.Visited = true;
            stack.Push(a);

            while (stack.Any() && final.Count < Graph.Count)
            {
                var x = stack.Pop();
                final.Add(x);

                foreach (var node in x.AdjacentNodes)
                {
                    if (!node.Visited)
                    {
                        node.Visited = true;
                        stack.Push(node);
                    }
                }
            }

            foreach (var node in final)
            {
                richTextBox1.Text += node.Name + "\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var queue = new Queue<Node>();
            var final = new List<Node>();

            queue.Enqueue(a);

            while (queue.Any() && final.Count < Graph.Count)
            {
                var x = queue.Dequeue();
                final.Add(x);
				
                foreach (var node in x.AdjacentNodes)
                {
                    if (!node.Visited) 
					{
						node.Visited = true;
                        queue.Enqueue(node);
					}
                }
            }

            foreach (var node in final)
            {
                richTextBox1.Text += node.Name + "\n";
            }
        }

        private void Form1_Load(object sender, EventArgs x)
        {
            a = new Node("A");
            b = new Node("B");
            c = new Node("C");
            d = new Node("D");
            e = new Node("E");
            f = new Node("F");

            a.AdjacentNodes.Add(b);
            a.AdjacentNodes.Add(c);
            a.AdjacentNodes.Add(d);

            b.AdjacentNodes.Add(a);

            c.AdjacentNodes.Add(a);
            c.AdjacentNodes.Add(e);
            c.AdjacentNodes.Add(f);

            d.AdjacentNodes.Add(a);
            d.AdjacentNodes.Add(f);

            e.AdjacentNodes.Add(c);

            f.AdjacentNodes.Add(c);
            f.AdjacentNodes.Add(d);

            Graph = new List<Node>()
            {
                a,
                b,
                c,
                d,
                e,
                f
            };
        }

        private List<Node> Graph;

        public Form1()
        {
            InitializeComponent();
        }
    }

    class Node
    {
        public string Name { get; set; }
        public List<Node> AdjacentNodes { get; set; }
        public bool Visited { get; set; }

        public Node(string name)
        {
            Name = name;
            AdjacentNodes = new List<Node>();
        }
    }
}
