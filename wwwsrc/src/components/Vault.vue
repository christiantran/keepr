<template>
    <div>
        <div>
            <!-- <li v-for="keep in vault"> -->
                <h3>{{keep.body}}</h3>
                <button @click="deleteKeep(keep)">Delete Keep</button>
        </div>
    </div>
</template>

<script>
  import router from "../router";
  // import keep from "./Keep";
  export default {
    name: "Vaults",
    data() {
      return {
        vault: {
          name: "",
          description: "",
        }
      };
    },
    components: {},
    mounted() {
      this.$store.dispatch("getVaults");
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      vaults() {
        return this.$store.state.vaults;
      },
      keeps() {
        return this.$store.state.keeps;
      }
    },
    methods: {
      addVault() {
        this.$store.dispatch("addVault", this.vault);
      },
      // setVault(vault) {
      //   this.$store.dispatch("setVault", vault);
      // },
      deleteVault(vault) {
        this.$store.dispatch("deleteVault", vault);
      },
      deleteKeep(keep) {
        this.$store.dispatch("deleteKeep", keep);
      }
    }
  };
</script>

<style>
</style>