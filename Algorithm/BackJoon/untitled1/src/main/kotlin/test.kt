class ActivityDetail : AppCompatActivity() {

    private var recyclerViewState: Parcelable? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_detail)

        postDetailRv.adapter = PostDetailAdapter()

        button.setOnClickListener {
            openAnotherActivity()
        }
    }

    override fun onResume() {
        super.onResume()
        if (recyclerViewState != null) {
            setSavedRecyclerViewState()
        }
    }

    private fun openAnotherActivity() {
        saveRecyclerViewState()
        Intent(this, ActivityAnother::class.java).apply {
            startActivity(this)
        }
    }

    private fun saveRecyclerViewState() {
        // LayoutManager를 불러와 Parcelable 변수에 리사이클러뷰 상태를 Bundle 형태로 저장한다
        recyclerViewState = postDetailRv.layoutManager!!.onSaveInstanceState()
    }

    private fun setSavedRecyclerViewState() {
        postDetailRv.layoutManager!!.onRestoreInstanceState(recyclerViewState)
    }

}