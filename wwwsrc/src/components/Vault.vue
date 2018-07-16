<template>
  <div>
    <div>
      <h1 class="vault-title">{{vault.name}}</h1>
    </div>

      <div>
        <!-- <div v-for="keep in keeps[vault._id]"> -->
        <h2 class="keep-title">{{keep.name}}</h2>
          <div>
            <button @click="deleteKeep(keep)">Delete Keep</button>
          </div>
        <!-- </div> -->
      </div>
  </div>
</template>

<script>
import router from "../router";
import keep from "./Keep";
export default {
  name: "Vaults",
  components: {
    keep
  },
  data() {
    return {
      keep: {
        name: "",
        parentId: ""
      }
    };
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
      this.$store.dispatch("addVault", this.newVault);
    },
    setVault(vault) {
      this.$store.dispatch("setVault", vault);
    },
    deleteVault(vault) {
      this.$store.dispatch("deleteVault", vault);
    }
  }
};
</script>

<style>
</style>