using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi.Business.BanDoXe
{
    public struct StructRoad {
        public bool Find;
        public string strFind;
        public string strLastFind;
        public string strAdd;
       /* public StructRoad() {
            this.Find = false;
            this.strFind = "";
            this.strLastFind = "";
            this.strAdd = "";
        }*/

        public StructRoad(bool find, string strfind, string strlastfind, string stradd) {
            this.Find = find;
            this.strFind = strfind;
            this.strLastFind = strlastfind;
            this.strAdd = stradd; 
        }


    }
    public class clsDefineConstant
    {

        #region Define 
        private string[] District = {"quận","quan","Q."}; 
        private string []Ward = {"phường","phuong","P."};
        private string []Social = { "xã" ,"xa","X."};
        private string []Lane = {"ngõ","ngo" };// define lane  as items
        private string []Bridge = { "cầu", "cau"};
        private string[] Hotel = {"KS","khach san","khách sạn"};
        private string[] Gasstation = { "cay xang", "cây xăng" };
        private string []Village  = {"làng","lang","L."};
        private string[] Market = { "cho","chợ"};
        private string[] Hospital = { "benh vien","bệnh viện","BV"};
        private string[] Hostel = { "nha nghi","nhà nghỉ","NN"};
        private string[] Gara = { "gara"};
        private string []Station = {"ga"};
        private string[] Bus = { "ben xe" , "bến xe","BX"};
        private string []Restaurant = { "nhà hàng", "nha hang","NH"};
        private string[] University = { "đại học","dai hoc","DH","ĐH"};
        private string[] Bank = { "ngan hang","ngân hàng"};

        #endregion 

        public clsDefineConstant() { 
        }
        /*
         *  
         */
        /// <summary>
        /// to check the string contain a constant string that it define above 
        /// </summary>
        /// <param name="strAdd"></param>
        /// <param name="arr"></param>
        /// <returns>
        /// if it find retur a object Struct road  
        /// else return empty object 
        /// </returns>
        private StructRoad ChexExistLane(string strAdd, string[] arr)
        {
            StructRoad objRoad = new StructRoad(false,"","","");
            string[] strTem = strAdd.Split(' ');
            //string[] strRemoveEmpty = new string[strTem.Length];
            //Xoa bo cac khoang trong tren mang
            int cout = 0;
           
            
            bool Find = false; 
            if (strTem.Length <= 0  ) return objRoad;
            for (int i = 0; i < strTem.Length; i++) {
                string strItem = strTem[i].ToLower();
                for (int j = 0; j < arr.Length; j++)  {
                    if (strItem.Contains(arr[j].ToLower())) { 
                        string strLastfind = "";
                        string strNameRoad= "";
                        string[] arrNumberRoad;
                        string noHouse = "";
                        string noRoad = "";
                        int Lenght = 0; 
                        if ((i + 1) < strTem.Length)
                        {
                            if (i >= 1 && isNumeric(strTem[0])) {
                                noHouse = strTem[0].Trim(); 
                            }
                            if (isNumeric(strTem[i + 1])) noRoad = strTem[i + 1];

                            // Get length substring 
                            for (int k = 0; k <= i; k++)
                            {
                                Lenght += strTem[k].Length;
                            }
                           
                                //Phan tich chuoi dung sau tu khoa Ngo 
                            if (noHouse.Length > 0)
                                strLastfind = noHouse;  
                            else  strLastfind = strTem[i + 1];
                            noRoad = strTem[i + 1];

                            arrNumberRoad =  parseSuffixTypeLane(strLastfind);
                            if (arrNumberRoad.Length > 0)
                            {
                                if (arrNumberRoad.Length==2 && isNumeric(arrNumberRoad[1])) 
                                    strNameRoad += arrNumberRoad[1].ToString();
                                else if (isNumeric(arrNumberRoad[0])) 
                                    strNameRoad += arrNumberRoad[0].ToString();

                               /*( if ( noRoad.Length >0)
                                strNameRoad += "," + strAdd.Substring(arr[j].Length + strNameRoad.Length + noRoad.Length+ 1);

                                else
                                strNameRoad += "," + strAdd.Substring(arr[j].Length + strNameRoad.Length  + 1);*/
                                string strResult = "";
                                strResult = strAdd.Substring(Lenght + noRoad.Length + i + 1);
                                if (noHouse.Length >0)
                                strNameRoad = noHouse + "," + strResult; 
                                else 
                                  strNameRoad = noRoad + "," + strResult; 
                            }
                            else strNameRoad ="1,"+ strLastfind; 
                        }
                         
                        objRoad = new StructRoad(true, arr[j].ToLower(), strLastfind, strNameRoad);
                         return objRoad; 
                    }   

                     }
                         
            }
            
            return objRoad; 
        }

        public StructRoad CheckExistConstant(string strAdd, string[] arr)
        {
            StructRoad objRoad = new StructRoad(false, "", "", "");
            string[] strTem = strAdd.Split(' ');
            bool Find = false;
            if (strTem.Length <= 0) return objRoad;
            for (int i = 0; i < strTem.Length; i++)
            {
                string strItem = strTem[i].ToLower();
                for (int j = 0; j < arr.Length; j++)
                {
                    if (strItem.Contains(arr[j].ToLower()))
                    {
                        string strLastfind = "";
                        string strNameRoad = "";
                        string[] arrNumberRoad;
                        if ((i + 1) < strTem.Length)
                        {
                            //Phan tich chuoi dung sau tu khoa Ngo 
                            strLastfind = strTem[i + 1];                            
                            strNameRoad += "," + strAdd.Substring(arr[j].Length + strNameRoad.Length + 1);                           
                        }

                        objRoad = new StructRoad(true, arr[j].ToLower(), strLastfind, strNameRoad);
                        return objRoad;
                    }

                }

            }
            return objRoad;
        }

        public StructRoad CheckFormatAddress(string strAdd) {
            StructRoad objRoad = new StructRoad(false, "", "", "");
            string[] strTem = strAdd.Split(' ');
            bool Find = false;
            string strNameNumber = "";
            strAdd = this.getPrefixString(strAdd);

            if (strTem.Length <= 0) return objRoad;
            if (strTem.Length >= 2)
            {
                if (isNumeric(strTem[0]))
                {
                    strNameNumber += strTem[0] + "," + strAdd.Substring(strTem[0].Length+1);

                }
                else strNameNumber += strTem[0];
                objRoad = new StructRoad(true, "", strNameNumber, strNameNumber); 
            }
            return objRoad; 
            
        }

        /// <summary>
        /// check string is numberic 
        /// </summary>        
        /// <returns></returns>
        public bool isNumeric(string val)
        {
            Double result;
            return Double.TryParse(val, out result); 
            //return Double.TryParse(val, NumberStyle,
              //  System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Remove some special char as : ',' 
        /// </summary>
        /// <param name="strAdd"></param>
        /// <returns></returns>
        public string RemoveCharLiteral(string strAdd) { 
            //strAdd = strAdd.IndexOf(
            string strTem = "";
            if (strAdd != "" && strAdd.Length > 0) { 
                  strAdd = strAdd.Replace(',',' ');
            }
            strAdd = strAdd.Trim(); 
            return strAdd; 
        }
        
        private string[] parseSuffixTypeLane (string strSuffixLane) {
            char[] arrConst = { '/',' ',',',';','-'};
            string[] arrTemstr = new string [0];
            
               // if (strSuffixLane != "" && strSuffixLane.Length > 0)
               // {
                    for (int i = 0; i < arrConst.Length; i++)
                    {   //arrTemstr = new string [] 
                        string[] arrTem = strSuffixLane.Split(arrConst[i]);
                        //arrTemstr = strSuffixLane.Split(arrConst[i]);
                        arrTemstr = new string[arrTem.Length];
                        arrTemstr = arrTem; 
                        break;
                    }
                    
                    return arrTemstr; 

               // }
                    
               // else arrTemstr = new string[0];
               // return arrTemstr; 
        }
        /// <summary>
        /// To split string address  when it contain  one of  item as   -- , [ ,(,
        ///  
        /// </summary>
        /// <returns>
        /// get prefix string
        /// </returns>
        public string getPrefixString(string strAdd) {
            string[] arrConst = {"--" ,"{","(","[","-" };
            string[] arrTem;
           // for (int i = 0; i < arrConst.Length; i++)
            //{
                //arrTem = strAdd.Split(arrConst, System.StringSplitOptions.None);
                
                arrTem = strAdd.Split(arrConst,System.StringSplitOptions.RemoveEmptyEntries);
                
                if (arrTem.Length > 0) return arrTem[0];
            //}
            
            return strAdd;                         
        }


        public List<StructRoad> getListPointConstfromParseString(string strAdd) {
            List<StructRoad> lstRoad = new List<StructRoad>();
            StructRoad objRoad = new StructRoad();
            /*List<string> lstPointConst = new List<string>();
            lstPointConst.Add(this.Bank);
            lstPointConst.Add(this.Bridge);
            lstPointConst.Add(this.Bus);
            lstPointConst.Add(this.Gara);
            lstPointConst.Add(this.Gasstation);
            lstPointConst.Add(this.Hospital);
            lstPointConst.Add(this.Hostel);
            lstPointConst.Add(this.Hotel);
            lstPointConst.Add(this.Market);
            lstPointConst.Add(this.Restaurant);
            lstPointConst.Add(this.Station);
            lstPointConst.Add(this.University);
            lstPointConst.Add(this.Ward);
            lstPointConst.Add(this.Social);*/                     
            objRoad = new StructRoad();
            objRoad = CheckExistConstant(strAdd, this.Bank);
            if (objRoad.Find) lstRoad.Add(objRoad);

            objRoad = new StructRoad();
            objRoad = CheckExistConstant(strAdd, this.Bridge);
            if (objRoad.Find) lstRoad.Add(objRoad);

            objRoad = new StructRoad();
            objRoad = CheckExistConstant(strAdd, this.Bus);
            if (objRoad.Find) lstRoad.Add(objRoad);

            objRoad = new StructRoad();
            objRoad = CheckExistConstant(strAdd, this.Gara);
            if (objRoad.Find) lstRoad.Add(objRoad);

            objRoad = new StructRoad();
            objRoad = CheckExistConstant(strAdd, this.Gasstation);
            if (objRoad.Find) lstRoad.Add(objRoad);

            objRoad = new StructRoad();
            objRoad = CheckExistConstant(strAdd, this.Hospital);
            if (objRoad.Find) lstRoad.Add(objRoad);

            objRoad = new StructRoad();
            objRoad = CheckExistConstant(strAdd, this.Market);
            if (objRoad.Find) lstRoad.Add(objRoad);

            objRoad = new StructRoad();
            objRoad = CheckExistConstant(strAdd, this.Market);
            if (objRoad.Find) lstRoad.Add(objRoad);


            objRoad = new StructRoad();
            objRoad = CheckExistConstant(strAdd, this.Market);
            if (objRoad.Find) lstRoad.Add(objRoad);

            objRoad = new StructRoad();
            objRoad = CheckExistConstant(strAdd, this.Restaurant);
            if (objRoad.Find) lstRoad.Add(objRoad);

            objRoad = new StructRoad();
            objRoad = CheckExistConstant(strAdd, this.Station);
            if (objRoad.Find) lstRoad.Add(objRoad);

            objRoad = new StructRoad();
            objRoad = CheckExistConstant(strAdd, this.University);
            if (objRoad.Find) lstRoad.Add(objRoad);
            return lstRoad; 
        }
        

        
        /*
         *  To parse the string which contain lane 
         */
        public  StructRoad getparseStringTypeLane(string strAdd)
        {
           // List <StructRoad> lstRoad = new List<StructRoad> (); 
            StructRoad objRoad = new StructRoad();                                   
            string strPrefix = "";
            strPrefix = this.getPrefixString(strAdd);
            objRoad = ChexExistLane(strPrefix, this.Lane);
            return objRoad;          
        }

    }
}
