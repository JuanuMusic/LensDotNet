using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client
{
    public enum PublicationReportReason
    {
        // Illegal
        ANIMAL_ABUSE,
        HARASSMENT,
        VIOLENCE,
        SELF_HARM,
        DIRECT_THREAT,
        HATE_SPEECH,

        // Sensitive content
        NUDITY,
        OFFENSIVE,

        // Fraud
        SCAM,
        UNAUTHORIZED_SALE,
        IMPERSONATION,

        // Spam
        MISLEADING,
        MISUSE_HASHTAGS,
        UNRELATED,
        REPETITIVE,
        FAKE_ENGAGEMENT,
        MANIPULATION_ALGO,
        SOMETHING_ELSE
    }
    public static class PublicationHelpers
    {
        public static ReportingReasonInputParams BuildReportingReasonInputParams(PublicationReportReason reason)
        {
            switch (reason)
            {
                case PublicationReportReason.VIOLENCE:
                    return new ReportingReasonInputParams
                    {
                        IllegalReason = new IllegalReasonInputParams { Reason = PublicationReportingReason.Illegal, Subreason = PublicationReportingIllegalSubreason.Violence }
                    };
                case PublicationReportReason.SELF_HARM:
                    return new ReportingReasonInputParams
                    {
                        IllegalReason = new IllegalReasonInputParams { Reason = PublicationReportingReason.Illegal, Subreason = PublicationReportingIllegalSubreason.ThreatIndividual }
                    };
                case PublicationReportReason.DIRECT_THREAT:
                    return new ReportingReasonInputParams
                    {
                        IllegalReason = new IllegalReasonInputParams { Reason = PublicationReportingReason.Illegal, Subreason = PublicationReportingIllegalSubreason.DirectThreat }
                    };
                case PublicationReportReason.HARASSMENT:
                case PublicationReportReason.HATE_SPEECH:
                    return new ReportingReasonInputParams
                    {
                        IllegalReason = new IllegalReasonInputParams { Reason = PublicationReportingReason.Illegal, Subreason = PublicationReportingIllegalSubreason.HumanAbuse }
                    };
                case PublicationReportReason.ANIMAL_ABUSE:
                    return new ReportingReasonInputParams
                    {
                        IllegalReason = new IllegalReasonInputParams { Reason = PublicationReportingReason.Illegal, Subreason = PublicationReportingIllegalSubreason.AnimalAbuse }
                    };
                case PublicationReportReason.SCAM:
                case PublicationReportReason.UNAUTHORIZED_SALE:
                    return new ReportingReasonInputParams
                    
                    {
                        FraudReason = new FraudReasonInputParams { Reason = PublicationReportingReason.Fraud, Subreason = PublicationReportingFraudSubreason.Scam }
                    };
                case PublicationReportReason.IMPERSONATION:
                    return new ReportingReasonInputParams
                    {
                        FraudReason = new FraudReasonInputParams { Reason = PublicationReportingReason.Fraud, Subreason = PublicationReportingFraudSubreason.Impersonation }
                    };
                case PublicationReportReason.NUDITY:
                    return new ReportingReasonInputParams
                    {
                        SensitiveReason = new SensitiveReasonInputParams { Reason = PublicationReportingReason.Sensitive, Subreason = PublicationReportingSensitiveSubreason.Nsfw }
                    };
                case PublicationReportReason.OFFENSIVE:
                    return new ReportingReasonInputParams
                    {
                        SensitiveReason = new SensitiveReasonInputParams { Reason = PublicationReportingReason.Sensitive, Subreason = PublicationReportingSensitiveSubreason.Offensive }
                    };
                case PublicationReportReason.MISLEADING:
                    return new ReportingReasonInputParams
                    {
                        SpamReason = new SpamReasonInputParams { Reason = PublicationReportingReason.Spam, Subreason = PublicationReportingSpamSubreason.Misleading}
                    };
                case PublicationReportReason.MISUSE_HASHTAGS:
                    return new ReportingReasonInputParams
                    {
                        SpamReason = new SpamReasonInputParams { Reason = PublicationReportingReason.Spam, Subreason = PublicationReportingSpamSubreason.MisuseHashtags }
                    };
                case PublicationReportReason.UNRELATED:
                    return new ReportingReasonInputParams
                    {
                        SpamReason = new SpamReasonInputParams { Reason = PublicationReportingReason.Spam, Subreason = PublicationReportingSpamSubreason.Unrelated }
                    };
                case PublicationReportReason.REPETITIVE:
                    return new ReportingReasonInputParams
                    {
                        SpamReason = new SpamReasonInputParams { Reason = PublicationReportingReason.Spam, Subreason = PublicationReportingSpamSubreason.Repetitive }
                    };
                case PublicationReportReason.FAKE_ENGAGEMENT:
                    return new ReportingReasonInputParams
                    {
                        SpamReason = new SpamReasonInputParams { Reason = PublicationReportingReason.Spam, Subreason = PublicationReportingSpamSubreason.FakeEngagement }
                    };
                case PublicationReportReason.MANIPULATION_ALGO:
                    return new ReportingReasonInputParams
                    {
                        SpamReason = new SpamReasonInputParams { Reason = PublicationReportingReason.Spam, Subreason = PublicationReportingSpamSubreason.ManipulationAlgo }
                    };
                case PublicationReportReason.SOMETHING_ELSE:
                    return new ReportingReasonInputParams
                    {
                        SpamReason = new SpamReasonInputParams { Reason = PublicationReportingReason.Spam, Subreason = PublicationReportingSpamSubreason.SomethingElse }
                    };
                default:
                    return default;
            }
        }
    }
}
