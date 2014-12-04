using System;
using GAsty.OasisModel;

namespace GAsty.Connectors
{
    public class IntensityConnector
    {
        /// <summary>
        /// 
        /// </summary>
        private int m_ProfileID;
        /// <summary>
        /// 
        /// </summary>
        private string m_ProfileDescription;
        /// <summary>
        /// 
        /// </summary>
        private ConnectorEnum m_ConnectorType;
        /// <summary>
        /// 
        /// </summary>
        private Model_Definition m_ModelDefinition;

        /// <summary>
        /// 
        /// </summary>
        private string m_ModelVersion;
        /// <summary>
        /// 
        /// </summary>
        private int m_PerilID;
        /// <summary>
        /// 
        /// </summary>
        private int m_AreaID;
        /// <summary>
        /// 
        /// </summary>
        private int m_PPA;
        /// <summary>
        /// 
        /// </summary>
        private double m_Max;
        /// <summary>
        /// 
        /// </summary>
        private double m_Min;
        /// <summary>
        /// 
        /// </summary>
        private float m_IntensityIncrement;
        /// <summary>
        /// 
        /// </summary>
        private string m_InterpolationRule;
        /// <summary>
        /// 
        /// </summary>

        public IntensityConnector()
        {
            this.m_ProfileID = 451;
            this.m_ProfileDescription = "PPA MinMax";
            this.m_ConnectorType = ConnectorEnum.IntensityConnector;
            this.m_ModelDefinition = new Model_Definition();
        }

        public void StartConnect()
        {
            this.m_ModelVersion = this.m_ModelDefinition.ModelVersion;

        }

        public void EndConnect()
        {


        }

        
        
    }
}
