using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassTestDll
{
    public delegate void ServiceMoveBedStatusDel(ServiceMoveBedResultArgs args);

    public delegate void ServiceAcqStatusDel(ServicAcqStatusArgs args);

    public delegate void ServiceCapabilityDel(ServiceCapabilityArgs args);

    public interface IScan
    {
        IList<ServiceImagingJob> Plan(string studyInstanceUID, IList<ServiceImagingJob> jobs);
        void Play(string studyInstanceUID, IList<ServiceImagingJob> jobs, string token);
        bool Cancel();
        void SkipOneBed(string rawDataUID, int bedNo);
        void CancelRecon(string reconInstanceUID);
        bool ApplyResource(string appName, IList<ServiceSystemResource> resourceList, out string token);
        void ReleaseResource();
        void EndStudy(string studyInstanceUID);
        void ServiceMoveBed(ServiceMoveBedParameters moveBedJob);
        event ServiceMoveBedStatusDel ServiceMoveBedStatusHandler;
        event ServiceAcqStatusDel ServiceAcqStatusHandler;
        event ServiceCapabilityDel GantryCapabilityHandler;
    }
    
    public class ServiceImagingJob
    {
        public ServiceAcqParameters Acq;
        public IList<ServiceReconParameters> ReconList;
        public List<ulong> ErrorCodeUIDList { get; set; }
        public ServiceImagingJob()
        {
            ReconList = new List<ServiceReconParameters>();
            Acq = new ServiceAcqParameters();
            ErrorCodeUIDList = new List<ulong>();
        }
    }
    //注释参数为待定
    public class ServiceReconParameters
    {
        public string ReconSeriesUID { get; set; }
        public string RawSeriesInstanceUID { get; set; }

        //public string ImageSize { get; set; }
        //public long TotalImagesSize { get; set; }
        //public float SliceThickness { get; set; }
        //public int RawSeriesNumber { get; set; }

        public int ReconBegin { get; set; }
        public int ReconEnd { get; set; }
        public string ReconSolution { get; set; }
        public uint ReconPriority { get; set; }
    }
    public class ServiceMoveBedParameters
    {
         public float BedHeight { get; set; }
         public float HorizontalPosition { get; set; }
         public string MoveBedToken{get;set;} 
    }
    public class ServiceAcqParameters
    {
        //注释参数为待定
        public IList<ServiceBedParameters> BedInfosList;
        public string RawSeriesInstanceUID { get; set; }

        //public string FrameOfReferenceUID { get; set; }
       // public Trigger Trigger;  
       // public bool HorizontalPositionAutoMove { get; set; }
        //public bool VerticalPositionAutoMove { get; set; }
        //public bool CouchBaseAutoMove { get; set; }
        //public bool AcqNeeded { get; set; }
        //public bool SendPlanNeeded { get; set; }
        public string ProtocolName { get; set; }
        public string BodyPartExamined { get; set; }
        public string BedDirection { get; set; }
        public bool IgnoreMove { get; set; }
        public string CouchBasePositionType { get; set; }
        //public ConsoleCouchBasePositionType CouchBasePosition;//用字符串约定
        public string AcquisitionMode { get; set; }
        public string ScanMode { get; set; }
        public int BedCountUnit { get; set; }
        public int NumberOfBeds { get; set; }
        public float BedHeight { get; set; }
        public string PatientPosition { get; set; }
        public string ProtocolKey { get; set; }
        public IList<ServiceUnitCoinWindow> UnitCoinWindowList { get; set; }
        public IList<ServiceCrossCoinWindow> CrossCoinWindowList { get; set; }
        public ServiceAcqParameters()
        {
            BedInfosList = new List<ServiceBedParameters>();
            UnitCoinWindowList = new List<ServiceUnitCoinWindow>();
            CrossCoinWindowList = new List<ServiceCrossCoinWindow>();
        }
    }
    public class ServiceUnitCoinWindow
    {
        public int UintNo { get; set; }
        public float CoincidenceWindow { get; set; }
    }
    public class ServiceCrossCoinWindow : ServiceUnitCoinWindow
    {
        public int UintNo1 { get; set; }
    }
    public class ServiceBedCountParameters : ServiceBedParameters
    {
        public float BedCount { get; set; }
        public int MaxBedDurationViaCounts { get; set; }
    }
    public class ServiceBedTimeParameters : ServiceBedParameters
    {
        public int BedDuration { get; set; }
     }
    public class ServiceBedParameters
    {
        public bool IsCountMode { get; set; }
        public float StartPosition { get; set; }
        public float BedHeight { get; set; }
        public int BedNo { get; set; }
        public IList<uint> Units { get; set; }
    }

    public class ServicAcqStatusArgs
    {
        public string RawSeriesInstanceUID { get; set; }
        public ulong AcqEndWithCode { get; set; }
        public ServicAcqStatus SeriesStatus { get; set; }
        public ServiceBedStatusArgs SeriesBedStatus { get; set; }
    }

    //注释参数为待定
    public class ServiceBedStatusArgs
    {
        public int bedNO { get; set; }
        public float bedProgress { get; set; }
        public long bedCurrentCounts { get; set; }
        public long bedTotdlCounts { get; set; }
        public DateTime bedStartTime { get; set; }
        public DateTime bedCurrentTime { get; set; }
        public ServiceBedStatus bedStatus { get; set; }
    }
    public class ServiceMoveBedResultArgs
    {
        public int actionCode { get; set; }
    }   

    public class ServicReconStatusArgs
    {
        public ReconStatus ReconResult { get; set; }
        public string StudyInstanceUID { get; set; }
    }
    
    public class ServiceCapabilityArgs
    {
        public float MaxHorizontalPosition { get; set; }
        public float MinHorizontalPosition { get; set; }
        public float HorizontalPosition { get; set; }
        public float MaxVerticalPosition { get; set; }
        public float MinVerticalPosition { get; set; }
        public float VerticalPosition { get; set; }
       // public float DiskSpace { get; set; }
    }
    public enum ServiceBedStatus
    {
        UnScan,
        Scanning,
        Scanned,
        ScanFailed,
        ScanCancel
    }
    public enum ReconStatus
    {
        Waiting = 0,
        Running = 1,
        Finished = 2,
        Fail = 3,
    }
    public enum ServicAcqStatus
    {
        SeriesStart,
        SeriesEnd,
    }
    public enum ServiceSystemResource
    {
        Acqusition,
        Reconstruction
    }
    public enum ConsoleCouchBasePositionType
    {
        CouchBasePosition_None,
        CouchBasePosition_CT,
        CouchBasePosition_PET,
        CouchBasePosition_Middle
    }
}

