using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi.Entity 
{
  public  class RoadEntity
  {
      protected int m_ID;
      public int ID
      {
          get { return m_ID; }
          set { m_ID = value; }
      }

      protected string m_NameEN;
      public string NameEN
      {
          get { return m_NameEN; }
          set { m_NameEN = value; }
      }

      protected string m_NameVN;
      public string NameVN
      {
          get { return m_NameVN; }
          set { m_NameVN = value; }
      }

      protected string m_VietTat;
      public string VietTat
      {
          get { return m_VietTat; }
          set { m_VietTat = value; }
      }

      protected string m_Polygon;
      public string Polygon
      {
          get { return m_Polygon; }
          set { m_Polygon = value; }
      }

      protected int m_Type;
      public int Type
      {
          get { return m_Type; }
          set { m_Type = value; }
      }

      protected int m_FK_CommuneID;
      public int FK_CommuneID
      {
          get { return m_FK_CommuneID; }
          set { m_FK_CommuneID = value; }
      }

      protected int m_FK_DistrictID;
      public int FK_DistrictID
      {
          get { return m_FK_DistrictID; }
          set { m_FK_DistrictID = value; }
      }

      protected int m_FK_ProvinceID;
      public int FK_ProvinceID
      {
          get { return m_FK_ProvinceID; }
          set { m_FK_ProvinceID = value; }
      }

      protected string m_MaXN;
      public string MaXN
      {
          get { return m_MaXN; }
          set { m_MaXN = value; }
      }

      protected float m_KinhDo;
      public float KinhDo
      {
          get { return m_KinhDo; }
          set { m_KinhDo = value; }
      }

      protected float m_ViDo;
      public float ViDo
      {
          get { return m_ViDo; }
          set { m_ViDo = value; }
      }
  }

  public class clsPOIEntity
  {
      protected int m_ID;
      public int ID
      {
          get { return m_ID; }
          set { m_ID = value; }
      }

      protected string m_NameVN;
      public string NameVN
      {
          get { return m_NameVN; }
          set { m_NameVN = value; }
      }

      protected string m_VietTat;
      public string VietTat
      {
          get { return m_VietTat; }
          set { m_VietTat = value; }
      }

      protected int m_Type;
      public int Type
      {
          get { return m_Type; }
          set { m_Type = value; }
      }

      protected string m_TypeName;
      public string TypeName
      {
          get { return m_TypeName; }
          set { m_TypeName = value; }
      }

      protected float m_KinhDo;
      public float KinhDo
      {
          get { return m_KinhDo; }
          set { m_KinhDo = value; }
      }

      protected float m_ViDo;
      public float ViDo
      {
          get { return m_ViDo; }
          set { m_ViDo = value; }
      }
  }

  public class clsPOITypeEntity
  {
      protected int m_Type;
      public int Type
      {
          get { return m_Type; }
          set { m_Type = value; }
      }

      protected string m_TypeName;
      public string TypeName
      {
          get { return m_TypeName; }
          set { m_TypeName = value; }
      }
  }
}
