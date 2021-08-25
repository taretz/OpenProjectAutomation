using System;
using System.Collections.Generic;
using OpenProject.infra.webRelated;
using OpenProject.pageObjects;
using OpenQA.Selenium;

namespace OpenProject.PageObjects
{
	public class NewProjectDialog : BasePage
	{
		private readonly Locator _projectNameTextBoxLocator = Locator.Get(By.Id("formly_3_textInput_name_0"), "Project name text box");
		private readonly Locator _advancedSettingsLocator = Locator.Get(By.XPath(@"//button[text()=' Advanced settings ']"), "Advanced settings button");
		private readonly Locator _descriptionLocator = Locator.Get(By.CssSelector("[data-qa-field-name='description'] p"), "Project description text box");
		private readonly Locator _statusDropDownLocator = Locator.Get(By.CssSelector("[data-qa-field-name='status'] ng-select"), "Project status list box");
		private readonly Locator _statusOptionLocator = Locator.Get(By.CssSelector("[role='option'] span:nth-child(2)"), "Project status options list");
		private readonly Locator _submitLocator = Locator.Get(By.CssSelector("[type='submit']"), "Submit button");

		public NewProjectDialog()
			: base(Locator.Get(By.Id("content"), "New project dialog"))
		{
		}

		public NewProjectDialog TypeProjectName(string projectName)
		{
			IWebElement el = bot.FindElement(() => containingElement, _projectNameTextBoxLocator);
			bot.TypeToElement(() => el, projectName);
			return this;
		}

		private void FillAdvancedSettingField(Action action)
		{
			bot.Click(() => containingElement, _advancedSettingsLocator);
			action.Invoke();
			bot.Click(() => containingElement, _advancedSettingsLocator);
		}

		public NewProjectDialog TypeProjectDescription(string description)
		{
			FillAdvancedSettingField(() =>
			{
				IWebElement el = bot.FindElement(() => containingElement, _descriptionLocator);
				bot.TypeToElement(() => el, description);
			});
			return this;
		}

		public NewProjectDialog SelectProjectStatus(ProjectStatus status)
		{
			FillAdvancedSettingField(() =>
			{
				bot.Click(() => containingElement, _statusDropDownLocator);
				bot.Click(() => containingElement, status.locator);
				// IReadOnlyCollection<IWebElement> statuses = bot.FindElement(() => containingElement, status.locator);
				// foreach (var s in statuses)
				// {
				// 	if (s.Text == status.Value)
				// 	{
				// 		bot.Click(() => s);
				// 		break;
				// 	}
				// }
			});
			return this;
		}

		public ProjectPage Create()
		{
			bot.Click(() => containingElement, _submitLocator);
			return pageFactory.ProjectPage();
		}
	}
}