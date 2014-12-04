using System;

namespace GAsty.OasisModel
{
    public class Model_Definition
    {
        #region Private Field
        /// <summary>
        /// The ID of the model development organisation
        /// </summary>
        private int m_OrganisationID;
        /// <summary>
        /// Model Supplier
        /// </summary>
        private string m_ModelSupplier;
        /// <summary>
        /// 
        /// </summary>
        private int m_ModelID;
        /// <summary>
        /// The size of the company and related parent company in annual turnover or employees
        /// </summary>
        private int m_SizeOfCompany;
        /// <summary>
        /// How many offices (campus for universites) worldwide
        /// </summary>
        private int m_NumOfCampus;
        /// <summary>
        /// For which country can the model may be used
        /// </summary>
        private string m_ModelForCountry;
        /// <summary>
        /// Which Perils (e.g. Wind, Quake, Fire Following, Flood, Storm Surge)
        /// </summary>
        private string m_Perils;
        /// <summary>
        /// What exposures are covered (e.g. property buildings and contents and BI)
        /// </summary>
        private string m_Interest;
        /// <summary>
        /// What lines of insurfance does it apply to (e.g. individuals, residentials, properties, commerical properties, treaty, marine, aviation?)
        /// </summary>
        private string m_LineOfBussiness;
        /// <summary>
        /// What is the description of the main model version provided
        /// </summary>
        private string m_PrincipleModelVersion;
        /// <summary>
        /// Waht variants if any are provided
        /// </summary>
        private string m_Variants;
        /// <summary>
        /// 
        /// </summary>
        private int m_Customer;
        /// <summary>
        /// The number of license used
        /// </summary>
        private int m_LicensesInUse;

        #endregion

        public Model_Definition()
        {
            this.m_OrganisationID = 0;
            this.m_ModelSupplier = "Imperial College London";
            this.m_ModelID = 0;
            this.m_SizeOfCompany = 6000;
            this.m_NumOfCampus = 3;
            this.m_ModelForCountry = "Great Britain";
            this.m_Perils = "Interdependency Hazards";
            this.m_Interest = "Infrastructure";
            this.m_LineOfBussiness = "Transport Infrastructure";
            this.m_PrincipleModelVersion = "V1.0";
            this.m_Variants = "Input-Output Infrastructure Model";
            this.m_Customer = 100;
            this.m_LicensesInUse = 1;
        }

        public int Organisation
        {
            get { return m_OrganisationID; }
        }

        public int ModelID
        {
            get { return m_ModelID; }
        }

        public int SizeOfCompany
        {
            get { return m_SizeOfCompany; }
        }

        public string ModelForContry
        {
            get { return m_ModelForCountry; }
        }

        public string Perils
        {
            get { return m_Perils; }
        }

        public string ModelInterest
        {
            get { return m_Interest; }
        }

        public string ModelSupplier
        {
            get { return m_ModelSupplier; }
        }

        public string ModelVersion
        {
            get { return m_PrincipleModelVersion; }
        }

        public int LicenseInUse
        {
            get { return m_LicensesInUse; }
        }



    }
}
