using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace BackgroundDesktopManager.Properties
{
	// Token: 0x02000014 RID: 20
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00002D2F File Offset: 0x00000F2F
		internal Resources()
		{
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002D37 File Offset: 0x00000F37
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("BackgroundDesktopManager.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002D63 File Offset: 0x00000F63
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002D6A File Offset: 0x00000F6A
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x04000074 RID: 116
		private static ResourceManager resourceMan;

		// Token: 0x04000075 RID: 117
		private static CultureInfo resourceCulture;
	}
}
