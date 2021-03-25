<template>
  <div class="container" dir="rtl">
    <div class="row">
      <div class="col-12 my-4">
        <h2 class=" text-info">لیست صنایع</h2>
      </div>
    </div>
    <div class="row">
      <div class="col-6">
        <div class="map row">
          <LMap
            @ready="onReady"
            @locationfound="onLocationFound"
            :zoom="zoom"
            :center="center"
          >
            <LTileLayer :url="url"></LTileLayer>

            <ul>
              <li v-for="(l, i) in latlong" :key="i">
                <LMarker :lat-lng="l"
                  ><l-tooltip>{{ l[2] }}</l-tooltip></LMarker
                >
              </li>
            </ul>
          </LMap>
        </div>
      </div>
      <div class="col-6 brew-list float-right ml-auto">
        <!-- <div class="card ml-auto" style="width:18rem">
          <ul class="list-group list-group-flush">
            <li class="li list-group-item" v-for="u in utm" :key="u.id">
              {{ u.name }} , {{ u.city }}
            </li>
          </ul>
        </div> -->
        <div class="example-tree">
          <tree
            :data="data"
            :options="opts"
            :filter="filter"
            ref="tree"
            @node:checked="d"
            dir="rtl"
          >
            <div
              @click="getUtmByid"
              slot-scope="{ node }"
              class="node-container"
            >
              <div class="node-text">{{ node.text }}</div>
              <div class="node-controls">
                <router-link :to="{ name: 'Industry', params: { id: node.id } }"
                  >مشاهده پروفایل صنعت</router-link
                >
                <p class="text-danger" @click="deleteIndustry(node.id)">
                  <a href="">
                    حذف صنعت
                  </a>
                </p>
              </div>
            </div>
          </tree>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { LMap, LTileLayer, LMarker, LTooltip } from "vue2-leaflet";

import axios from "axios";
export default {
  name: "Map",
  components: {
    LMap,
    LTileLayer,
    LMarker,
    LTooltip
  },
  data() {
    return {
      ids: [],
      titles: [],
      data: this.getData(),
      datas: [],
      opts: {
        minFetchDelay: 1000,
        fetchData: node => {
          return Promise.resolve(this.datas[node.id - 1]);
        },
        checkbox: false
      },
      filters: {
        time(time) {
          return +time;
        }
      },
      url: "https://{s}.tile.osm.org/{z}/{x}/{y}.png",
      zoom: 5.3,
      center: [31.887178, 54.3579483],
      bounds: null,
      utm: [],

      results: null,
      country: [],
      latlong: [],
      confirmed: []
    };
  },
  methods: {
    getData() {
      return new Promise(resolve => {
        setTimeout(_ => {
          resolve(this.titles);
          console.log(_);
        }, 100);
      });
    },

    initEventViewer(event) {
      const events = this.events;
      return function(node, newNode) {
        let nodeText = "-";
        let targetNode = newNode && newNode.text ? newNode : node;

        if (targetNode && targetNode.text) {
          nodeText = targetNode.text;
        }
        let key = 0;
        events.push(
          Object.assign({}, event, { time: new Date(), nodeText, id: key++ })
        );

        console.log(event, arguments);
      };
    },
    // location and utm
    onLocationFound(location) {
      console.log(location);
    },
    onReady(mapObject) {
      mapObject.locate();
    },
    getUtm() {
      axios.get("/api/Utm").then(res => {
        res.data.forEach(q => {
          var a = [];
          a.push(q.latitude);
          a.push(q.lngitude);
          a.push(q.name);
          this.latlong.push(a);
          console.log(this.latlong);
        });
        this.utm = res.data;

        res.data.forEach(q => {
          this.ids.push(q.id);
          this.titles.push({
            text: q.name,
            isBatch: true,
            id: q.id
          });
        });
      });
    },
    getUtmByid() {
      let g = [2, 5, 6, 7, 8, 9];
      g.forEach(d => {
        console.log(d);
        axios.get(`api/Utm/id?id=${d}`).then(res => {
          console.log(res.data);
          let a = [];
          a.push({ text: ` شهر :  ${res.data.city} ` });
          a.push({ text: ` کدپستی :  ${res.data.postalCode} ` });
          a.push({ id: ` کدپستی :  ${res.data.id} ` });

          this.datas.push(a);
          console.log(this.datas);
        });
      });
    },
    deleteIndustry(id) {
      axios.delete(`/api/Utm/${id}`).then(res => console.log(res.data));
    }
  },

  async created() {},
  async beforeMount() {},
  async mounted() {
    await this.getUtm();
    await this.getUtmByid();
  }
};
</script>
<style scoped>
.map {
  height: 80vh;
  border: 1px solid #888;
}
ul li {
  list-style: none;
}
</style>
