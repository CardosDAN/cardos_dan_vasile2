using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Threading;

namespace cardos_dan_vasile2
{
    class PizzaMachine : Component
    {
        public delegate void PizzaCompleteDelegate();
        public event PizzaCompleteDelegate PizzaComplete;
        public delegate void DoughnutCompleteDelegate();
        public event DoughnutCompleteDelegate DoughnutComplete;
        private PizzaType mIngredients;
        DispatcherTimer pizzaBakeTimer;
        private void InitializeComponent()
        {
            this.pizzaBakeTimer = new DispatcherTimer();
            this.pizzaBakeTimer.Tick += new System.EventHandler(this.pizzaBakeTimer_Tick);
        }
        private void pizzaBakeTimer_Tick(object sender, EventArgs e)
        {
            Pizza aPizza = new Pizza(this.Ingredients);
            mPizzas.Add(aPizza);
            PizzaComplete();
        }
        public PizzaMachine()
        {
            InitializeComponent();
        }


        public bool Enabled
        {
            set
            {
                pizzaBakeTimer.IsEnabled = value;
            }
        }
        public int Interval
        {
            set
            {
                pizzaBakeTimer.Interval = new TimeSpan(0, 0, value);
            }
        }

        
        public PizzaType Ingredients
        {
            get
            {
                return mIngredients;
            }
            set
            {
                mIngredients = value;
            }
        }
        private System.Collections.ArrayList mPizzas = new System.Collections.ArrayList();
        public Pizza this[int Index]
        {
            get
            {
                return (Pizza)mPizzas[Index];
            }
            set
            {
                mPizzas[Index] = value;
            }
        }
        public void MakePizzas(PizzaType dIngredients)
        {
            Ingredients = dIngredients;

            switch (Ingredients)
            {
                case PizzaType.Canibale: Interval = 3; break;
                case PizzaType.Margherita: Interval = 2; break;
                case PizzaType.Pepperoni: Interval = 5; break;
                case PizzaType.Quattro_Stagioni: Interval = 7; break;
                case PizzaType.Veggie: Interval = 4; break;
            }
            pizzaBakeTimer.Start();
        }

    }// end PizzaMachine class
    enum PizzaType
    {
        Margherita,
        Pepperoni,
        Veggie,
        Quattro_Stagioni,
        Canibale
    }
    class Pizza
    {
        private PizzaType mIngredients; // câmp
        public PizzaType Ingredients // proprietate
        {
            get //metoda get
            {
                return mIngredients;
 }
            set //metoda set
            {
                mIngredients = value;
            }
        }
        private float mPrice = .50F;
        private float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }
        private readonly DateTime mTimeOfCreation;
        public DateTime TimeOfCreation
        {
            get
            {
                return mTimeOfCreation;
            }
        }
        public Pizza(PizzaType aIngredients) // constructor
        {
            mTimeOfCreation = DateTime.Now;
            mIngredients = aIngredients;
        }
    }// end Pizza class 
}
