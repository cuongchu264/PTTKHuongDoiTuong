<template>
  <main>
    <div class="container">
      <!--carousel-->
      <div>
        <b-carousel
          id="carousel-1"
          v-model="slide"
          :interval="3000"
          controls
          indicators
          background="#ababab"
          witdh="100"
          style="text-shadow: 1px 1px 2px #333;"
          @sliding-start="onSlideStart"
          @sliding-end="onSlideEnd"
        >
          <!-- Text slides with image -->
        <b-carousel-slide
            v-for="(CarouselItem, index) in listCarousels" :key="index"
            :caption="CarouselItem.caption"
            :text="CarouselItem.text"
            :img-src="CarouselItem.img"
          >
            <p><a class="btn btn-lg btn-success" :href="CarouselItem.link">Check it</a></p>
        </b-carousel-slide>          
        </b-carousel>
      </div>

      <!--card-banner-->
      <div>
        <b-card
          overlay
          img-src="https://media3.giphy.com/media/3o7TKA9qD3bBwK6VYA/giphy.gif?cid=790b76114d4556f7cc1d62cf09659cb8471317e58322865c&rid=giphy.gif&ct=g"
          img-alt="Card Image"
          text-variant="light"
          title="SẮP TRỞ LẠI"
          sub-title="Nike Air Jordan 1 High Bred Toe"
          img-height="600"
        >
          <b-card-text>
            Đánh dấu sự trở lại của những mẫu Air Jordan được yêu thích nhất trong lịch sử.
            <p><a class="btn btn-success mt-2" href="https://hnbmg.com/su-tro-lai-cua-nike-air-jordan-1-high-black-toe-30700.html" >Check it</a></p>
          </b-card-text>
        </b-card>
      </div>

      <!--HP title-->
      <div class="text-center mt-2">
        <h1>" SẢN PHẨM HOT "</h1>
      </div>

      <!--hot product-->
      <div>
        <b-tabs v-model="tabIndex" content-class="mt-3" align="center" active-nav-item-class="font-weight-bold text-uppercase text-success">
          <!--Nike-->
          <b-tab title="Nike"  active :title-link-class="linkClass(0)">
            <div class="row">
              <div v-for="(product, index) in listHotNike" 
                  :key="index" class="col-12 col-md-4 mb-3 text-center">
                <item 
                  :product="product"
                />
              </div>
            </div>
          </b-tab>
          <!--Adidas-->
          <b-tab title="Adidas" :title-link-class="linkClass(1)">
            <div class="row">
              <div v-for="(product, index) in listHotDas" 
                  :key="index" class="col-12 col-md-4 mb-3 text-center">
                <item 
                  :product="product"
                />
              </div>
            </div>
          </b-tab>
          <!--Vans-->
          <b-tab title="Vans" :title-link-class="linkClass(2)">
            <div class="row">
              <div v-for="(product, index) in listHotVans" 
                  :key="index" class="col-12 col-md-4 mb-3 text-center">
                <item 
                  :product="product"
                />
              </div>
            </div>
          </b-tab>
          <!--Convers-->
          <b-tab title="Converse" :title-link-class="linkClass(3)">
            <div class="row">
              <div v-for="(product, index) in listHotCon" 
                  :key="index" class="col-12 col-md-4 mb-3 text-center">
                <item 
                  :product="product"
                />
              </div>
            </div>
          </b-tab>
        </b-tabs>
      </div>

      <!--new3-->
      <div class="p-5 mb-4 bg-light rounded-3 new3 mt-3">
        <div class="container-fluid py-5 text-white">
          <img src="https://i1.wp.com/statics.hnbmg.com/hi%CC%80nh-1.jpg?fit=800%2C606&ssl=1" class="img-fluid" alt="">
          <h1 class="display-5 fw-bold">Recap | 5THEWAY® Tại Sole Ex Tour 2019 Với /make global local/ WORKSHOP™ & /nothing/ Early Releasing Collection™</h1>
          <p class="col-md-8 fs-4">Throwback những khoảnh khắc đáng nhớ nhất của 5THEWAY® tại sự kiện Sole Ex Tour 2019 và đón chờ /nothing/ COLLECTION™ sẽ được ra mắt chính thức vào cuối tuần này.</p>
          <p><a class="btn btn-success btn-lg" href="https://hnbmg.com/recap-5theway-tai-sole-ex-tour-2019-voi-make-global-local-workshop-nothing-early-releasing-collection-63668.html">Check it »</a></p>
        </div>
      </div>
      
      <!--new4&5-->
      <div class="row align-items-md-stretch">
        <div class="col-md-6">
          <div class="h-100 p-5 text-white bg-dark rounded-3 new4">
            <h2>5THEWAY® Mang Đến 4 Điểm Mới Cùng Workshop /make global local/ Và 9 Items Của Bộ Sưu Tập /nothing/ Tại Sole Ex Tour 2019</h2>
            <p>Cuối tuần này, 5THEWAY® sẽ chính thức có mặt tại Sole Ex Tour 2019 để trình làng bộ sưu tập mới nhất mang tên /nothing/ và kể câu chuyện về streetwear thông qua workshop /make global local/.</p>
            <p><a class="btn btn-success btn-lg" href="https://hnbmg.com/5theway-mang-den-4-diem-moi-cung-workshop-make-global-local-va-9-items-cua-bo-suu-tap-nothing-tai-sole-ex-tour-2019-63569.html">Check it »</a></p>
          </div>
        </div>
        <div class="col-md-6">
          <div class="h-100 p-5 bg-light text-white border rounded-3 new5">
            <h2>Hé lộ loạt chương trình hấp dẫn tại kỳ Sneaker Fest hoành tráng nhất từ trước đến giờ</h2>
            <p>Bạn sẽ không thể nào ngờ được sự hoành tráng, chuyên nghiệp và "ăn chơi" của Sneaker Fest năm nay!</p>
            <p><a class="btn btn-success btn-lg" href="https://hnbmg.com/he-lo-loat-chuong-trinh-vo-cung-hap-dan-xuat-hien-tai-ky-sneaker-fest-hoanh-trang-nhat-38712.html">Check it »</a></p>
          </div>
        </div>
      </div>
    </div>
  </main>   
</template>
<style>
  .carousel-item img {
      height:80vh!important ;
  }
  .new3{
    background-image: url('https://i1.wp.com/statics.hnbmg.com/hi%CC%80nh-1.jpg?fit=800%2C606&ssl=1') !important;
  }
  .new4{
    background-image: url('https://i0.wp.com/statics.hnbmg.com/h%C3%ACnh-1-cover.jpg?fit=800%2C418&ssl=1') !important;
  }
  .new5{
    background-image: url('https://i1.wp.com/statics.hnbmg.com/19424533_1962278090650252_2835836213799667799_n.jpg?fit=800%2C533&ssl=1') !important;
  }
</style>
<script>
import item from '@/components/index/ProductSummary.vue'
import catalogApi from '@/api/catalogApi'
export default {
  components:{
        item,
    },
  data(){
    return {
      slide: 0,
      sliding: null,
      tabIndex: 0,
      listHotProducts: [],
      listCategories: [],
      listCarousels: [],
      listHotNike: [],
      listHotDas: [],
      listHotVans: [],
      listHotCon: [],
    }
  },

  async created(){
    await this.getCategories()
    await this.getCarousels()
    await this.getHotNike()
    await this.getHotDas()
    await this.getHotVans()
    await this.getHotCon()

  },
  methods :{
    async getCarousels(){
      try{
        const { data } = await catalogApi.getCarousels(this.$axios)
        console.log(data)

        this.listCarousels = data
      }catch(err){
        console.log(err)
      }
    },

    async getCategories(){
      try{
        const { data } = await catalogApi.getCategories(this.$axios)
        console.log(data)

        this.categories = data
      }catch(err){
        console.log(err)
      }
    },

    // hot nike
    async getHotNike(){
      try{
        const { data } = await catalogApi.getHotProductsviaCategoryId(this.$axios, 1)
        console.log(data)

        this.listHotNike = data
      }catch(err){
        console.log(err)
      }
    },
    // hot das
    async getHotDas(){
      try{
        const { data } = await catalogApi.getHotProductsviaCategoryId(this.$axios, 2)
        console.log(data)

        this.listHotDas = data
      }catch(err){
        console.log(err)
      }
    },
    // hot vans
    async getHotVans(){
      try{
        const { data } = await catalogApi.getHotProductsviaCategoryId(this.$axios, 3)
        console.log(data)

        this.listHotVans = data
      }catch(err){
        console.log(err)
      }
    },
    // hot converse
    async getHotCon(){
      try{
        const { data } = await catalogApi.getHotProductsviaCategoryId(this.$axios, 4)
        console.log(data)

        this.listHotCon = data
      }catch(err){
        console.log(err)
      }
    },

    onSlideStart(slide) {
        this.sliding = true
      },
    onSlideEnd(slide) {
        this.sliding = false
    },
    linkClass(idx) {
        if (this.tabIndex === idx) {
          return ['bg-success', 'text-light']
        } else {
          return ['bg-light', 'text-secondary']
        }
    }
  },
}
</script>
