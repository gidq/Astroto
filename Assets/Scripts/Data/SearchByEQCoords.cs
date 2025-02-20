using System;
using UnityEngine;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices.WindowsRuntime;

public class SearchByEQCoords : MonoBehaviour
{
    public Snapshot snap;
    private void Start()
    {
        //Scrape(83.82469f, -5.3762f);
    }
    public void Scrape(float ra, float dec)
    {
        float fov = 15.6f;
        // Defines a driver variable which interacts with the web page
        IWebDriver webDriver = new ChromeDriver();

        // Defines a url variable.
        string url = $"https://gidq.github.io/Astroto.dev/";
        // Navigate to the defined URL
        webDriver.Navigate().GoToUrl(url);

        // Maximize the window
        webDriver.Manage().Window.Maximize();
        // Find the form inputs
        IWebElement raDecInput = webDriver.FindElement(By.ClassName("RA-DEC"));
        IWebElement fovInput = webDriver.FindElement(By.ClassName("FOV"));
        IWebElement buttonInput = webDriver.FindElement(By.ClassName("Generate"));

        raDecInput.SendKeys(ra + " " + dec);
        fovInput.SendKeys(fov.ToString());
        buttonInput.Click();

        
        


    }
}
