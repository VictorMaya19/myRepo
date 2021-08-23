package selenium.webdriver;

import java.util.List;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;




public class TakeHome {
	static WebDriver driver;
	static String price;
	static String confirmPrice;

	public static void main(String[] args) throws InterruptedException {
		
		System.setProperty("webdriver.chrome.driver", "C:\\WorkSpace\\chromedriver_win32\\chromedriver.exe");

		driver = new ChromeDriver();
		
		driver.get("https://www.tcgplayer.com/search/magic/product?productLineName=magic&page=1");
		driver.manage().window().maximize();
		
		//perform search
		
		driver.findElement(By.id("autocomplete-input")).sendKeys("Squall");
		driver.findElement(By.cssSelector("[value='conduct product search']")).click();
		Thread.sleep(1000);
		
		//verify number of results
		
		String resultCount = driver.findElement(By.cssSelector("[class='results']")).getText();
		String[] splitResultCount1 = resultCount.split("of ");
		String[] splitResultCount2 = splitResultCount1[1].split(" results");
		int resultsCountInt = Integer.parseInt(splitResultCount2[0]);
		
		List<WebElement>resultElements =  driver.findElements(By.cssSelector("[class='search-result']"));
		int resultElementsInt = resultElements.size();
		
			if(resultElementsInt == resultsCountInt) {
				System.out.println("result count and elements on page match");
			}
			else {
				System.out.println("result count and elements on page DONT match");
			}
		
		//filter results
			
		driver.findElement(By.id("FinalFantasyTCG-filter-label")).click();
		Thread.sleep(1000);
		List<WebElement>resultElements2 =  driver.findElements(By.cssSelector("[class='inventory__price-with-shipping']"));
		
		
		//grab price of first item on page
		
		for (WebElement webElement : resultElements2) {
            price = webElement.getText();
            break;
        }
		
		List<WebElement>resultElements3 =  driver.findElements(By.cssSelector("[class='search-result']"));
		for (WebElement webElement : resultElements3) {
            webElement.click();
            break;
        }
		
		Thread.sleep(2000);
		confirmPrice = driver.findElement(By.xpath("//*[@class='spotlight__price']")).getText();
		
		//verify price
		
		if(price.equals(confirmPrice)) {
			System.out.println("Prices match");
		}
		else {
			System.out.println("Prices DONT match");
		}
		
		//add to cart
		
		driver.findElement(By.xpath("//*[starts-with(@id,'btnAddToCart_FS')]")).click();
		Thread.sleep(1000);
		
		//verify number of items in cart
		
		String numOfItems = driver.findElement(By.xpath("//*[@data-aid='numberOfItemsValue']")).getText();
		if(numOfItems.equals("1")) {
			System.out.println("Number of items is 1");
		}
		else {
			System.out.println("Number of items is not 1");
		}
		
		
		//clear cart
		
		driver.findElement(By.cssSelector("[data-aid='editYourCart']")).click();
		Thread.sleep(1000);
		driver.findElement(By.xpath("//*[contains(text(),'Remove')]")).click();
		
		Thread.sleep(2000);
		
		driver.quit();
	}

}

