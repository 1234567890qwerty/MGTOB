# Poker Bot Ignat Documentation
=============================================
Team Labyrinth-4 members:
  - Andrei Boyadjiev
  - Mihaela Ivanova
  - Emil Tishinov
- - - -
The algorithm of the both is called every time when a decision should be made. A random deck is created and then cards are drawn. This is repeated 1000 times to achieve maximal probability of the expected result. After iterating 1000 times over random results the percentage of the winning cases is taken and returned to the both decision making part. This techique is called Monte Carlo Algorithm <br/>
## Monte Carlo Algorithm
1. Monte Carlo simulation: a simulation is a fictitious representation of reality,<br/>
a Monte Carlo method is a technique that can be used to solve a mathematical or statistical problem, and a Monte Carlo simulation uses repeated sampling <br/>
to determine the properties of some phenomenon (or behavior). Examples
   - Simulation: Drawing one pseudo-random uniform variable from the interval [0,1] can be used to simulate the tossing of a coin:<br/> 
   If the value is less than or equal to 0.50 designate the outcome as heads, but if the value is greater than 0.50 designate the outcome as tails. <br/>
   This is a simulation, but not a Monte Carlo simulation.
   - Monte Carlo method: Pouring out a box of coins on a table, and then computing the ratio of coins that land heads versus tails is a Monte<br/>
   Carlo method of determining the behavior of repeated coin tosses, but it is not a simulation.
   - Monte Carlo simulation: Drawing a large number of pseudo-random uniform variables from the interval [0,1], and assigning values less than or equal to 0.50<br/>
   as heads and greater than 0.50 as tails, is a Monte Carlo simulation of the behavior of repeatedly tossing a coin.
1. Kalos and Whitlock point out that such distinctions are not always easy to maintain. For example, the emission of radiation from atoms is a natural stochastic<br/>
process. It can be simulated directly, or its average behavior can be described by stochastic equations that can themselves be solved using Monte Carlo methods.<br/>
"Indeed, the same computer code can be viewed simultaneously as a 'natural simulation' or as a solution of the equations by natural sampling."<br/>
Monte Carlo simulation methods do not always require truly random numbers to be useful — while for some applications, such as primality testing, unpredictability <br/>
is vital.Many of the most useful techniques use deterministic, pseudorandom sequences, making it easy to test and re-run simulations.<br/>
The only quality usually necessary to make good simulations is for the pseudo-random sequence to appear "random enough" in a certain sense.<br/>
What this means depends on the application, but typically they should pass a series of statistical tests. Testing that the numbers are uniformly <br/>
distributed or follow another desired distribution when a large enough number of elements of the sequence are considered is one of the simplest,<br/>
and most common ones. Weak correlations between successive samples is also often desirable/necessary.<br/>
Sawilowsky lists the characteristics of a high quality Monte Carlo simulation:<br/>
    - the (pseudo-random) number generator has certain characteristics (e.g., a long "period" before the sequence repeats)<br/>
    - the (pseudo-random) number generator produces values that pass tests for randomness<br/>
    - there are enough samples to ensure accurate results<br/>
    - the proper sampling technique is used<br/>
    - the algorithm used is valid for what is being modeled<br/>
    - it simulates the phenomenon in question.<br/>
1. Pseudo-random number sampling algorithms are used to transform uniformly distributed pseudo-random numbers into numbers that are distributed according<br/>
to a given probability distribution.<br/>
Low-discrepancy sequences are often used instead of random sampling from a space as they ensure even coverage and normally have a faster <br/>
order of convergence than Monte Carlo simulations using random or pseudorandom sequences. Methods based on their use are called quasi-Monte Carlo methods.<br/>

=============================================
## Decision Making of Ignat
For this part of the poker bot the design pattern chain of responsibility is used. There is an abstract class Desion which is inherited of each of the possible decision classes that the both can make:
~~~c#
     internal abstract class Decision
    {
        protected Decision Successor { get; set; }

        public void SetSuccessor(Decision successor)
        {
            this.Successor = successor;
        }

        public abstract void BasedOnProbabilityDecision(double probability, GetTurnContext context, IBrainHelper brainHelper);
    }
~~~
The chain of responsibility goes this way:
AllInDecision --><br/>  
HalfMoneyIn --><br/> 
RaiseDecision --> <br/>
SmallRaiseDecision --><br/> 
CheckCallDecision --><br/>
BadLuckDecision 
