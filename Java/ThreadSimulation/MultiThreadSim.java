import java.util.Random;
/**
 * Runs simulation in multiple threads
 * @author A'Jee Sieka
**/ 
public class MultiThreadSim implements Runnable {
  private int[][] table;
  private Random r;
  private String report;
  private String file;
/**
 * Constuctor
 * @param simTable The generated table
**/ 
  public MultiThreadSim(int[][] simTable) {
    table = simTable;
    r = new Random();
    report = "";
    file = "";
  }
/**
 * Increase the given value by 20%-80%
 * @param value The target value
 * @return Returns the increased value
**/ 
  public int simulateIncrease(int value) {
    double factor =((r.nextInt(60) + 20)) / 100d;
    factor += 1;
    double d = factor * value;
    return (int) d;
  }
/**
 * Simulates running each process in the table; writes a report when the simulation has been completed, noting the current thread
**/
  public void run() {
    for (int i = 0; i < table.length; i++) {
      int newTime = simulateIncrease(table[i][3]);
      try {
        long startTime = System.currentTimeMillis();
        Thread.sleep(newTime);
        long endTime = System.currentTimeMillis();
        
        System.out.print("Request " + table[i][2] + " Processed ("+ Thread.currentThread().getName() + ")\n");
        report += "Current Thread: " + Thread.currentThread().getName() + " Echelon: " + table[i][0] + " Priority: " + table[i][1] + " Request: " + table[i][2]
          + " Start (ms): " + startTime + " End (ms): " + endTime + " Processing Time (ms): " + newTime + "\n";
        
        file += Thread.currentThread().getName() + "," + table[i][0] + "," + table[i][1] + "," + table[i][2] + "," + startTime + "," + endTime + ","
          + newTime + "\n";
      }
      catch (Exception e) {
      }
    }
    System.out.print(report);
  }
/**
 * Writes a file-ready report for the simulation in .csv format
 * @param s An input string
 * @param isBeginning Whether String s has already been written to by a previous thread
 * @return Returns the file-string
**/
  public String getReport(String s, boolean isBeginning) {
    if (isBeginning) {
      s += "Thread,Echelon,Priority,Request-Code,Begin-Time,End-Time,Processing-Time(MS),\n";
      s += file;
      return s;
    }
    else {
      s += file;
      return s;
    }
  }
}