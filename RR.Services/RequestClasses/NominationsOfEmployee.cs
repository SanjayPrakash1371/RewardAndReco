using RR.Models.OtherRewardsInfo;
using RR.Models.PeerToPeerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR.Services.RequestClasses
{
    public  class NominationsOfEmployee
    {

        public string nominatorId {  get; set; }
        public List<PeerToPeer> peerToPeers { get; set; }= new List<PeerToPeer>();

        public List<OtherRewards> OtherRewards { get; set; } = new List<OtherRewards>();
    }
}
