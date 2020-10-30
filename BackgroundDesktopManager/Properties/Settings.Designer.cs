using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace BackgroundDesktopManager.Properties
{
	// Token: 0x02000015 RID: 21
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002D72 File Offset: 0x00000F72
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000076 RID: 118
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
