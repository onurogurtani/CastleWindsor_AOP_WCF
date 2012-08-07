using System;
using System.Text;
using System.Xml;
using Castle.DynamicProxy;

namespace CastleWindsor_AOP_WCF.Aspects
{
    public class Logging : IInterceptor
    {
        #region IInterceptor Members

        public void Intercept(IInvocation invocation)
        {
            var xmlDoc = new XmlDocument();
            XmlElement rootNode = xmlDoc.CreateElement("Parameters");
            xmlDoc.AppendChild(rootNode);

            var sb = new StringBuilder();
            sb.AppendFormat("Method Called:{0} \n",
                            invocation.Method.Name);
            TextLogHelper.WriteLog(sb.ToString());
            sb.Length = 0;
            sb.Append("Parameters':");
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                XmlElement parentNode = xmlDoc.CreateElement(invocation.Method.GetParameters()[i].Name);
                parentNode.SetAttribute("value",
                                        invocation.Arguments[i] == null ? "" : invocation.Arguments[i].ToString());
                if (xmlDoc.DocumentElement != null)
                    xmlDoc.DocumentElement.PrependChild(parentNode);
            }
            TextLogHelper.WriteLog((sb + xmlDoc.InnerXml));
            sb.Length = 0;

            try
            {
                invocation.Proceed();
                TextLogHelper.WriteLog("Result of " + invocation.Method.Name + " is: " + "Success" + Environment.NewLine);
            }
            catch
            {
            }
            finally
            {
                TextLogHelper.WriteLog(invocation.Method.Name + "is finished");
            }
        }

        #endregion

        public string CreateParametersXml()
        {
            var xmlDoc = new XmlDocument();
            XmlElement rootNode = xmlDoc.CreateElement("Parameters");
            xmlDoc.AppendChild(rootNode);
            for (int i = 0; i < 3; i++)
            {
                XmlElement parentNode = xmlDoc.CreateElement("Parameter" + i);
                parentNode.SetAttribute("value", i.ToString());
                if (xmlDoc.DocumentElement != null) xmlDoc.DocumentElement.PrependChild(parentNode);
            }
            return xmlDoc.InnerXml;
        }
    }
}