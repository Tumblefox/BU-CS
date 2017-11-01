import java.io.*;
/**
 * Run the single and multi threaded simulations, then write the results to one or more files
 * @author A'Jee Sieka
**/
public class ThreadTesting {
  
  public static void main(String[] args) {
    
    ThreadSimulation sim = new ThreadSimulation(5000);
    
    SingleThreadSim single = new SingleThreadSim(sim.getTable());
    Thread t1 = new Thread(single);
    t1.start();
    try {t1.join();} catch(Exception e) {}
    try {toFile(single.getReport(), "SingleThread");} catch(Exception e) {System.out.print("Error: File NOT Written!\n");}
    
    int[][] firstHalf = splitTable(sim.getTable(), 0, 2499);
    int[][] secondHalf = splitTable(sim.getTable(), 2500, 4999);
    MultiThreadSim d1 = new MultiThreadSim(firstHalf);
    MultiThreadSim d2 = new MultiThreadSim(secondHalf);
    
    Thread t2 = new Thread(d1);
    Thread t3 = new Thread(d2);
    
    t2.start();
    t3.start();
    
    try {t2.join(); t3.join();} catch(Exception e) {}
    
    try {
      String s = "";
      s += d2.getReport(d1.getReport("", true), false);
      toFile(s, "MultiThread");
    } 
    catch(Exception e) {System.out.print("Error: File NOT Written!\n" + e.getMessage() + "\n");}
    
  }
/**
 * Splits the table between two vertices, then returns the resulting sub-table
 * @param table The target table
 * @param first The index of the first row
 * @param last The index of the last row
 * @return Returns the resulting sub-table
**/ 
  public static int[][] splitTable(int[][] table, int first, int last) {
    int newSize = last - first + 1;
    int[][] newTable = new int[newSize][table[0].length];
    
    for (int i = first; i < last + 1; i++) {
      newTable[i - first] = table[i];
    }
    
    return newTable;
  }
/**
 * Writes the given string to a file with the specified file name
 * @param s The given string
 * @param filename The given filename
 * @throws FileNotFoundException
**/
  public static void toFile(String s, String filename) throws FileNotFoundException {
    PrintWriter writer = new PrintWriter(new File(filename + ".csv"));
    
    writer.write(s);
    writer.close();
    
    System.out.print("File Written!\n");
  }
}