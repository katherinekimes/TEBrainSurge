<template>
  <div id="app">
    <div class="header">
      <div id="te_brainsurge">
        <img src="@/Assets/tearrow.png" />
        <p>TE Brain Surge</p>
      </div>
      <div id="te_tagline">
        <p>Elevate your study habits</p>
      </div>
    </div>

    <div id="nav">
      <router-link id="nav-link" tag="button" :to="{ name: 'createcard' }">Create A New Card</router-link>
      <router-link id="nav-link" tag="button" :to="{ name: 'getmycards' }">Get My Cards</router-link>
      <router-link id="nav-link" tag="button" :to="{ name: 'getallcards' }">Get All Cards</router-link>
      <router-link id="nav-link" tag="button" :to="{ name: 'createdeck' }">Create A New Deck</router-link>
      <router-link id="nav-link" tag="button" :to="{ name: 'getalldecks' }">Get All Decks</router-link>
      <router-link
        id="nav-link"
        tag="button"
        v-on:click="logout"
        :to="{ name: 'login'}"
      >Click to Logout</router-link>
    </div>
    <router-view />
    <div id="background">
      <img src="@/Assets/blackBoardBackground.jpg" />
    </div>
  </div>
</template>


<script>
import auth from "./auth";
export default {
  name: "header",
  methods: {
    logout: function() {
      this.$router.push("/login");
    }
  }
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css?family=Electrolize&display=swap");
@import url("https://fonts.googleapis.com/css?family=Lakki+Reddy&display=swap");
@import url("https://fonts.googleapis.com/css?family=Indie+Flower&display=swap");

#nav {
  text-align: center;
}

#nav-link {
  margin-left: 10px;
  margin-right: 10px;
}

#background img {
  width: 100%;
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  z-index: -1;
}

.header {
  display: grid;
  /* grid-template-columns: 15% 85%; */
  grid-template-rows: 75% 25%;
  grid-template-areas: "brainsurge" "tagline";
  /* background-color: aquamarine; */
  /* background-image: url("./Assets/lightning.jpg"); */
  background-repeat: no-repeat;
  background-size: 300px 100%;
  text-align: center;
  /* background-color: rgb(149, 245, 130); */
  height: 100px;
  margin-bottom: 25px;
}

/* #te_arrow {
  grid-area: arrow;
  width: 256px;
  margin-left: 40px;
}

#te_arrow img {
  max-height: 100%;
} */

#te_brainsurge {
  display: flex;
  grid-area: brainsurge;
  justify-content: center;
  /* align-items: center; */
  font-size: 60pt;
  /* justify-items: auto; */
  font-family: "Lakki Reddy", cursive;
}

#te_brainsurge p {
  color: white;
}

#te_brainsurge img {
  max-height: 100%;
  margin-right: 30px;
}

#te_tagline {
  display: flex;
  grid-area: tagline;
  justify-content: center;
  align-items: center;
  font-size: 20pt;
  justify-items: auto;
  font-family: "Indie Flower", cursive;
  margin-top: 30px;
}

#te_tagline p {
  color: rgb(144, 241, 135);
}
</style>

